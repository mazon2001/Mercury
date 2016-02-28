using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace Mercury
{
    public class FeedbackValidator
    {
        //I would expect to store the user feedback into a database, the load the data into stores that are kept up to date
        //and would allow my class access to these stores to look up the current feedback and email addresses.
        //To make sure the user has not placed feedback, but for the sake of this test I will just use these two Dictionaries
        private Dictionary<string, FeedbackEntity> currentFeedback;
        private Dictionary<string,string> currentEmails;

        public FeedbackValidator()
        {
            //The dictionaries are case insensitive
            currentEmails = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            currentFeedback = new Dictionary<string, FeedbackEntity>(StringComparer.InvariantCultureIgnoreCase);
        }

        //This function is to allow me to populate my dictionaries for testing.
        public FeedbackValidator(Dictionary<string, FeedbackEntity> existingFeedback, Dictionary<string,string> existingEmails)
        {
            currentEmails = existingEmails;
            currentFeedback = existingFeedback;
        }

        public void CheckUserName(string username)
        {
            if (String.IsNullOrWhiteSpace(username))
                throw new ValidationException("Invalid Username");
            //The username can only have characters between a-z and A-Z.
            if(!Regex.IsMatch(username, @"^[a-zA-Z]+$"))
                throw new ValidationException("Invalid Username");
            if(username.Length > 20)
                throw new ValidationException("Invalid Username");
        }

        public void CheckUserNameNotUsed(string username)
        {
            if (currentFeedback.ContainsKey(username))
                throw new ValidationException("Feedback already placed for given user");
        }

        public void CheckRating(int rating)
        {
            //IF rating is less than 1 or greater than 5 then it is invalid.
            if(rating < 1 || rating > 5)
                throw new ValidationException("Invalid rating");
        }

        public void CheckEmailAddress(string email)
        {
            var emailAddress = new EmailAddressAttribute();
            //The EmailAddressAttribute class will valid the email for me.
            if(!emailAddress.IsValid(email))
                throw new ValidationException("Invalid email address");

            //Make sure the email has not already been used by a different user.
            if (currentEmails.ContainsKey(email))
                throw new ValidationException("Email already exists");

        }



        public void placeFeedback(FeedbackEntity feedback)
        {
            /*As I do not know where this code is based, I do not want this validator
              to check the date and time as it might fail because of time zones differances.
              I am relaying on that the FeedbackEnitiy has got a non nullable datetime and that
              where ever this entity is coming from, it is using it's current local date and time*/

            CheckUserName(feedback.userName);
            CheckUserNameNotUsed(feedback.userName);
            CheckRating(feedback.rating);
            CheckEmailAddress(feedback.email);

            //As said above, I would expect this would be written to a database.
            //But for the sake of this problem, I have just kept them in memory.
            currentFeedback.Add(feedback.userName, feedback);
            currentEmails.Add(feedback.email, feedback.userName);

        }
    }
}
