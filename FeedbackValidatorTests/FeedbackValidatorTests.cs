using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mercury;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FeedbackValidatorTests
{
    [TestClass]
    public class FeedbackValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckEmptyUserName()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            feedbackValidator.CheckUserName("");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckEmptyUserNameFromPlaceFeedback()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "" };
            feedbackValidator.placeFeedback(feedback);
        }

        
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckWhiteSpaceUserName()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            feedbackValidator.CheckUserName("    ");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckWhiteSpaceUserNameFromPlaceFeedback()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "      " };
            feedbackValidator.placeFeedback(feedback);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckUserNameWithNumbers()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            feedbackValidator.CheckUserName("Mazon1");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckUserNameWithNumbersFromPlaceFeedback()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "Mazon1" };
            feedbackValidator.placeFeedback(feedback);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckUserNameWithSpecialChar()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            feedbackValidator.CheckUserName("Mazon!");
        }


        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckUserNameWithSpecialCharFromPlaceFeedback()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "Mazon!" };
            feedbackValidator.placeFeedback(feedback);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckUserNameThatIsTooLong()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            feedbackValidator.CheckUserName("MazonMazonMazonMazonM");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckUserNameThatIsTooLongFromPlaceFeedback()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "MazonMazonMazonMazonM" };
            feedbackValidator.placeFeedback(feedback);
        }

        [TestMethod]
        public void CheckValidUserName()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            try
            {
                feedbackValidator.CheckUserName("Mazon");
            }
            catch(Exception)
            {
                Assert.IsTrue(false,"Username should be Valid");
            }
        }

        [TestMethod]
        public void CheckValidUserNameFromPlaceFeedback()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            try
            {
                var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "Mazon" };
                feedbackValidator.placeFeedback(feedback);
            }
            catch (Exception)
            {
                Assert.IsTrue(false, "Username should be Valid");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckNegativeRating()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            feedbackValidator.CheckRating(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckNegativeRatingFromPlaceFeedback()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = -1, userName = "Mazon" };
            feedbackValidator.placeFeedback(feedback);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForZeroRating()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            feedbackValidator.CheckRating(0);
        }


        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForZeroRatingFromPlaceFeedback()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 0, userName = "Mazon" };
            feedbackValidator.placeFeedback(feedback);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForRatingAbove5()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            feedbackValidator.CheckRating(6);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForRatingAbove5FromPlaceFeedback()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 6, userName = "Mazon" };
            feedbackValidator.placeFeedback(feedback);
        }

        [TestMethod]
        public void CheckForValidRating()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            try
            {
                feedbackValidator.CheckRating(1);
                feedbackValidator.CheckRating(2);
                feedbackValidator.CheckRating(3);
                feedbackValidator.CheckRating(4);
                feedbackValidator.CheckRating(5);

            }
            catch (Exception)
            {
                Assert.IsTrue(false, "All ratings between 1 to 5 should be valid");
            }
        }

        [TestMethod]
        public void CheckForValidRatingFromPlaceFeedback()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            try
            {
                var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "Mazon" };
                feedbackValidator.placeFeedback(feedback);
            }
            catch (Exception)
            {
                Assert.IsTrue(false, "Rating of 1 should be valid");
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForBlankEmailAddress()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            feedbackValidator.CheckEmailAddress("");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForBlankEmailAddressFromPlaceFeedback()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            var feedback = new FeedbackEntity() { email = "", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "Mazon" };
            feedbackValidator.placeFeedback(feedback);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForInvalidEmailAddress1()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            feedbackValidator.CheckEmailAddress("email@email");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForInvalidEmailAddressFromPlaceFeedback()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            var feedback = new FeedbackEntity() { email = "email@email", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "Mazon" };
            feedbackValidator.placeFeedback(feedback);
        }


        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForInvalidEmailAddress2()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            feedbackValidator.CheckEmailAddress("email");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForInvalidEmailAddress3()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            feedbackValidator.CheckEmailAddress("email@email@com");
        }

        [TestMethod]
        public void CheckForValidEmailAddress()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            try
            {
                feedbackValidator.CheckEmailAddress("Email@email.com");

            }
            catch (Exception)
            {
                Assert.IsTrue(false, "The email address Email@email.com should be valid");
            }
        }

        [TestMethod]
        public void CheckForValidEmailAddressFromPlaceFeedback()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            try
            {
                var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "Mazon" };
                feedbackValidator.placeFeedback(feedback);
            }
            catch (Exception)
            {
                Assert.IsTrue(false, "The email address user@hotmail.com should be valid");
            }
        }

        [TestMethod]
        public void CheckForValidEmailAddress2()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            try
            {
                feedbackValidator.CheckEmailAddress("person@work.nz");

            }
            catch (Exception)
            {
                Assert.IsTrue(false, "The email address person@work.nz should be valid");
            }
        }

        [TestMethod]
        public void CheckForValidEmailAddress3()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            try
            {
                feedbackValidator.CheckEmailAddress("email.address@email.co.nz");

            }
            catch (Exception)
            {
                Assert.IsTrue(false, "The email address email.address@email.co.nz should be valid");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForDuplicateFeedback()
        {
            Dictionary<string, FeedbackEntity> currentFeedback = new Dictionary<string, FeedbackEntity>(StringComparer.InvariantCultureIgnoreCase);
            Dictionary<string, string> currentEmails = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

            currentFeedback.Add("Mazon", new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "Mazon" });
            FeedbackValidator feedbackValidator = new FeedbackValidator(currentFeedback, currentEmails);

            feedbackValidator.CheckUserNameNotUsed("Mazon");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForDuplicateFeedbackFromPlaceFeedback()
        {
            Dictionary<string, FeedbackEntity> currentFeedback = new Dictionary<string, FeedbackEntity>(StringComparer.InvariantCultureIgnoreCase);
            Dictionary<string, string> currentEmails = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

            currentFeedback.Add("Mazon", new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "Mazon" });
            FeedbackValidator feedbackValidator = new FeedbackValidator(currentFeedback, currentEmails);
            var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "Mazon" };
            
            feedbackValidator.placeFeedback(feedback);
        }



        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForDuplicateFeedbackWithDifferentCasing()
        {
            Dictionary<string, FeedbackEntity> currentFeedback = new Dictionary<string, FeedbackEntity>(StringComparer.InvariantCultureIgnoreCase);
            Dictionary<string, string> currentEmails = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

            currentFeedback.Add("MAZON", new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "Mazon" });
            FeedbackValidator feedbackValidator = new FeedbackValidator(currentFeedback, currentEmails);

            feedbackValidator.CheckUserNameNotUsed("mazon");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForDuplicateFeedbackWithDifferentCasingFromPlaceFeedback()
        {
            Dictionary<string, FeedbackEntity> currentFeedback = new Dictionary<string, FeedbackEntity>(StringComparer.InvariantCultureIgnoreCase);
            Dictionary<string, string> currentEmails = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

            currentFeedback.Add("MAZON", new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "Mazon" });
            FeedbackValidator feedbackValidator = new FeedbackValidator(currentFeedback, currentEmails);
            var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "Mazon" };

            feedbackValidator.placeFeedback(feedback);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForDuplicateEmailAddress()
        {
            Dictionary<string, FeedbackEntity> currentFeedback = new Dictionary<string, FeedbackEntity>(StringComparer.InvariantCultureIgnoreCase);
            Dictionary<string, string> currentEmails = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            currentEmails.Add("user@hotmail.com", "Mazon");
            FeedbackValidator feedbackValidator = new FeedbackValidator(currentFeedback, currentEmails);
            feedbackValidator.CheckEmailAddress("user@hotmail.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckForDuplicateEmailAddressFromPlaceFeedback()
        {
            Dictionary<string, FeedbackEntity> currentFeedback = new Dictionary<string, FeedbackEntity>(StringComparer.InvariantCultureIgnoreCase);
            Dictionary<string, string> currentEmails = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            currentEmails.Add("user@hotmail.com", "Mazon");
            FeedbackValidator feedbackValidator = new FeedbackValidator(currentFeedback, currentEmails);

            var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "Hey Great stuff", rating = 1, userName = "Mazon" };

            feedbackValidator.placeFeedback(feedback);
        }

        [TestMethod]
        public void CheckThatBlankFeedbackIsValid()
        {
            FeedbackValidator feedbackValidator = new FeedbackValidator();
            var feedback = new FeedbackEntity() { email = "user@hotmail.com", date = DateTime.Now, feedback = "", rating = 1, userName = "Mazon" };    
            try
            {
                feedbackValidator.placeFeedback(feedback);

            }
            catch (Exception)
            {
                Assert.IsTrue(false, "Blank feedback should be valid");
            }
        }
    }
}
