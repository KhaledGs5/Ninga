import cv2
from cvzone.HandTrackingModule import HandDetector
import mouse
import numpy as np
import pyautogui


cap = cv2.VideoCapture(0)
cam_w, cam_h = 640, 480
cap.set(3, cam_w)
cap.set(4, cam_w)

frameRate = 100
detector = HandDetector(detectionCon=0.75, maxHands=1)


smoothing_factor = 0.25
prev_x, prev_y = None, None

while True:
    success, img = cap.read()
    img = cv2.flip(img, 1)
    hands, img = detector.findHands(img, flipType=True)
    cv2.rectangle(img, (frameRate, frameRate), (cam_w - frameRate, cam_h - frameRate), (255, 0, 255), 2)

    if hands:
        lmlist = hands[0]['lmList']
        ind_x, ind_y = lmlist[8][0], lmlist[8][1]
        cv2.circle(img, (ind_x, ind_y), 5, (0, 255, 255), 2)
        conv_x = int(np.interp(ind_x, (frameRate, cam_w - frameRate), (0, 1920)))
        conv_y = int(np.interp(ind_y, (frameRate, cam_h - frameRate), (0, 1080)))

        if prev_x is not None and prev_y is not None:
            conv_x = int(smoothing_factor * conv_x + (1 - smoothing_factor) * prev_x)
            conv_y = int(smoothing_factor * conv_y + (1 - smoothing_factor) * prev_y)

        mouse.move(conv_x, conv_y)
        prev_x, prev_y = conv_x, conv_y

        fingers = detector.fingersUp(hands[0])
        if fingers[4] == 1:
            pyautogui.mouseDown()

    cv2.imshow("Camera Feed", img)
    cv2.waitKey(1)