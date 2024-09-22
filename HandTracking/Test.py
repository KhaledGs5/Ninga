import cv2
from cvzone.HandTrackingModule import HandDetector


def main():
    detector = HandDetector(detectionCon=0.65, maxHands=1)

    cap = cv2.VideoCapture(0)
    cam_w, cam_h = 640, 480
    cap.set(3, cam_w)
    cap.set(4, cam_h)

    while True:
        success, img = cap.read()
        img = cv2.flip(img, 1)

        hands, img = detector.findHands(img, flipType=True)
        if hands:
            for hand_landmarks in hands:
                landmark_list = hand_landmarks['lmList']
                print(landmark_list)

        cv2.imshow("Camera Feed", img)
        if cv2.waitKey(1) & 0xFF == ord('q'):
            break

    cap.release()
    cv2.destroyAllWindows()


if __name__ == "__main__":
    main()
