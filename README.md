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








Based on the column names provided, I will create a Jupyter Notebook script that performs a comprehensive data analysis, exploring trends in your dataset. The script will:
	1.	Import the dataset.
	2.	Conduct basic exploratory data analysis (EDA).
	3.	Identify key trends based on columns like time, participants, multitasking, chats, emails, and responses.
	4.	Use visualizations to uncover patterns and trends.

Here’s the Python code:

# Importing required libraries
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns

# Step 1: Load the dataset
# Replace 'your_file.xlsx' with the path to your Excel file
file_path = 'your_file.xlsx'
data = pd.read_excel(file_path)

# Step 2: Basic Exploration
print("Dataset Overview:")
print(data.head())
print("\nData Information:")
print(data.info())
print("\nMissing Values:")
print(data.isnull().sum())

# Step 3: Data Cleaning
# Fill missing values if necessary
data.fillna(0, inplace=True)

# Step 4: Exploratory Data Analysis (EDA)
# Descriptive statistics for numerical columns
print("\nDescriptive Statistics:")
print(data.describe())

# Plotting column-wise insights
plt.figure(figsize=(12, 6))
sns.heatmap(data.corr(), annot=True, cmap="coolwarm")
plt.title("Correlation Matrix")
plt.show()

# Step 5: Trend Analysis
# Analyzing trends over time
if 'Date' in data.columns:
    data['Date'] = pd.to_datetime(data['Date'])  # Ensure 'Date' is datetime
    trend_data = data.groupby('Date').sum()
    trend_data['Sum of Duration'].plot(title="Meeting Duration Over Time", figsize=(10, 5))
    plt.show()

# Analyzing organizer trends
if 'Organiser Region' in data.columns:
    region_trends = data.groupby('Organiser Region').sum()
    region_trends['Sum of Duration'].plot(kind='bar', title="Total Duration by Region", figsize=(10, 5))
    plt.show()

# Attendance trends
if 'Sum of Number of attendees who joined the meeting on time' in data.columns:
    data['On Time Percentage'] = (
        data['Sum of Number of attendees who joined the meeting on time'] /
        data['Sum of Intended participant count']
    ) * 100
    plt.figure(figsize=(10, 5))
    plt.hist(data['On Time Percentage'].dropna(), bins=20, edgecolor='k', alpha=0.7)
    plt.title("Distribution of On-Time Attendance")
    plt.xlabel("Percentage")
    plt.ylabel("Frequency")
    plt.show()

# Multitasking analysis
if 'Average of Number of attendees multitasking' in data.columns:
    plt.figure(figsize=(10, 5))
    sns.boxplot(data=data, y='Average of Number of attendees multitasking')
    plt.title("Multitasking Distribution")
    plt.show()

# Communication trends: chats, emails, and redundant attendees
if 'Sum of Number of chats sent during the meeting' in data.columns:
    plt.figure(figsize=(10, 5))
    plt.plot(data['Sum of Number of chats sent during the meeting'], label='Chats Sent')
    plt.plot(data['Sum of Number of emails sent during the meeting'], label='Emails Sent')
    plt.legend()
    plt.title("Chats and Emails Sent During Meetings")
    plt.show()

# Step 6: Export Insights
# Save cleaned data and insights
cleaned_file_path = 'cleaned_data.xlsx'
data.to_excel(cleaned_file_path, index=False)
print(f"Cleaned data saved to {cleaned_file_path}")

Key Features:

	•	Correlation Matrix: Displays relationships between numerical columns.
	•	Time-Series Analysis: Analyzes trends over dates.
	•	Region-Based Insights: Explores trends by organizer regions.
	•	Attendance Analysis: Examines on-time attendance rates and multitasking.
	•	Communication Metrics: Analyzes chats and emails sent during meetings.

Next Steps:

a. Would you like specific visualizations added for any other column?
b. Should I include advanced trend detection using machine learning techniques?





