# Custom Email Sender using C# Razor Pages
## This project demonstrates how to use C# Razor Pages to send custom emails from your application.

### Technologies Used
1) C#
2) Razor Pages
3) SMTP protocol

### Getting Started
1) Clone the repository to your local machine.
2) Open the solution file in Visual Studio.
3) Build the solution to restore the necessary packages.
4) Open RegisterAccountService.cs file in the RazorHtmlEmail.Common folder replace "<ADD YOUR EMAIL HERE>" and "<PASSWORD>" with your own email and password.
(smtp needs to be set up under apps in google security)
Run the application.

### How to Use
Run CustomEmailSender 
Enter the recipient's email address, First name, and Last anem in the form.
Click the Send button to send the email.
Code Structure
The main logic for sending emails is contained within the RegisterAccountService.cs file in the RazorHtmlEmail.Common folder. This class turns the html into string by
calling _razorViewToStringRenderer.RenderViewToStringAsync() where _razorViewToStringRenderer is an instance of IRazorViewToStringRenderer which then calls the correct email 
template (as many as needed can be added) and then uses the SMTP protocol to send emails.

### To Add more email templates
1) RazorHtmlEmails.RazorClassLib/Views/Emails folder, create a new floder with email name
2) Add model with record that takes in any data needed to create email as params
3) Design you're email in the razor page
4) add a Task in IRegisterAccountService interface found in RazorHtmlEmail.Common folder
5) add the method to create and send the email in RegisterAccountService class

The index.cshtml.cs file in the Pages folder contains the code for handling user input and invoking the EmailSender service to send the email.

#### Disclaimer: This project was built off a article i once read, ill add the reference here when i find it
