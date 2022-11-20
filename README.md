# A Classroom Monitoring System

This project is designed to:

1- Take a video input of a classroom.

2- Detect the faces of people present in the Classroom.

3- Recognize the faces.

4- Determine which students are attentive and which students are inattentive.

5- Store the data of the students with their names and attentiveness levels in a csv file.

## Challenges

1 - Detecting Faces.

2 - Getting Embeddings for faces.

3 - Training model Clustering/Classification/Similarly to recognise the faces.

4 - Find a suitable model for attentiveness/inattentiveness classification.

5 - Train the attentiveness/inattentiveness model.

6 - Create a pipeline for all three models.

6 - Run the pipelined models on a video input.

7 - Extract the data from the pipelined models and store them on a csv file.

8 - Take out the average of attentiveness/inattentiveness of each student in the classroom while also automatically taking their attendance.

9 - Create a user friendly UI which can be used to run the program and store the csv files.

## Face Detection
For Detecting the faces we used MTCNN from facenet_pytorch which is a State-of-The-Art Model.

## Face Recognition
### Dataset
For Facial recognition the dataset was collected by myself by taking pictures of students from the classroom and using MTCNN to detect them and extract images of faces. These images were later used to train facial recognition model and also used to make the dataset for attentive and inattentive classification model.

InceptionResnetV1 model was used to perform facial recognition with vggface2 pretrained weights. The recognition model works pretty well and is able to recognise faces even in low quality videos. Only 7-10 images of a face are required to train the model to be able to recognise faces in most situations.

## Attentive/Inattentive Classification

For this purpose I used ResMaskingNet + 6 model which was pretrained to detect 6 emotion classes. I added a new final layer to the model with only 2 outputs and finetuned the model on on my own collected dataset to make it an attentive/inattentive classifier.

## GUI

The gui was made using windows forms and was connected to the python program using C#. PythonOnlyScript.py was connected with the gui keeping all trained models on device.
