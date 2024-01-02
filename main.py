import cv2
from cvzone.HandTrackingModule import HandDetector
import socket

# Webcam
cap = cv2.VideoCapture(0)
w = 1920
h = 1080
cap.set(3, w)
cap.set(4, h)

# Hand detector
detector = HandDetector(detectionCon=0.75, maxHands=1)

# Communication
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)

start = True
while start:
    # Get the frame from webcam
    success, img = cap.read()
    img = cv2.flip(img, 1)
    # Hands
    hands, img = detector.findHands(img)

    data = []
    # Landmark values (x,y,z) * 21
    if hands:
        # Get the first hand detected
        hand = hands[0]
        # Get the landmark list
        lmList = hand['lmList']
        # print(f"lmList: {lmList}")
        for lm in lmList:
            data.extend([lm[0], h - lm[1], lm[2]])
        # print(f"data: {data}")

        # Send the data
        sock.sendto(str.encode(str(data)), serverAddressPort)

    img = cv2.resize(img, (0, 0), None, 0.5, 0.5)
    cv2.imshow("Image", img)
    cv2.waitKey(1)