using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using HealthMate_UI;

namespace HealthMate
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //Start the program
            StartProgram();
        }
        static void StartProgram()
        {
            //to support arabic language in VS
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("1: للمتابعة باللغة العربية");
            Console.WriteLine("2: Continue In English Language");
            Console.WriteLine("3: Exit / لمغادرة البرنامج\n");
            Console.Write("Enter your choice number / ادخل رقم اختيارك:\n");

            int language = Convert.ToInt16(Console.ReadLine());
            switch (language)
            {
                case 1:
                    arabic();
                    break;

                case 2:
                    eng();
                    break;

                case 3:
                    break;

                default:
                    Console.WriteLine("اختيار خاطئ، اعد المحاولة");
                    Console.WriteLine("Invalid choice, try again\n");
                    StartProgram();
                    break;
            }
        }

        static void eng()
        {   //connect to the DataBase
            System.Data.SqlClient.SqlConnection sqlConnection;
            string connectionString = @"Data Source=DESKTOP-QUB8L8T\SQLEXPRESS;Initial Catalog=UserInfoDB;Integrated Security=True";

            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                Console.WriteLine("\n1: Login into an existing account\n2: Create a new account\n");
                Console.Write("Enter your choice number: \n");
                int account = Convert.ToInt16(Console.ReadLine());
                switch (account)
                {
                    case 1:
                        Console.WriteLine("Enter UserName:");
                        string EUserName = Console.ReadLine();

                        Console.WriteLine("Enter Password:");
                        string EPassword = Console.ReadLine();

                        string readQuery = "SELECT * FROM UserInfo WHERE UserName = @Username";

                        using (SqlCommand command = new SqlCommand(readQuery, sqlConnection))
                        {
                            command.Parameters.AddWithValue("@Username", EUserName);

                            SqlDataReader reader = command.ExecuteReader();
                            //Add login logic and read data from DataBase
                            if (reader.Read())
                            {
                                string userNameFromDB = reader["UserName"].ToString();
                                string passwordFromDB = reader["Password"].ToString();

                                string encryptionKey0 = "hTbHfq5rC5dAby6DJt8P3w==";
                                string initializationVector0 = "6mRwZNlJb/WLbCyk4n+bBg==";

                                var encryptionService0 = new EncryptionService(encryptionKey0, initializationVector0);

                                string decryptedPass = encryptionService0.Decrypt(passwordFromDB);

                                if (EPassword == decryptedPass)
                                {
                                    Console.WriteLine("\nLogin successful!\n");
                                    string WlcMessage = reader["FName"].ToString();
                                    Console.WriteLine($"Welcome {WlcMessage}\n");
                                }
                                else
                                {
                                    Console.WriteLine("Login failed. Please check your password.");
                                    eng();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Login failed. User not found.");
                                eng();
                            }
                            
                            while (true)
                            {
                                Console.WriteLine("\n1: Show exactly how Old You Are.");
                                Console.WriteLine("2: Calculate The Difference Between Two Dates.");
                                Console.WriteLine("3: View General Information About Your Health.\n");
                                Console.WriteLine("4: Update your information.");
                                Console.WriteLine("5: Exit.");
                                Console.WriteLine("6: Reselect language.\n");
                                Console.Write("Enter your choice number: \n");

                                int choice = Convert.ToInt16(Console.ReadLine());
                                switch (choice)
                                {
                                    case 1:
                                        CalculateAge();
                                        break;

                                    case 2:
                                        CalculateDateDifference();
                                        break;

                                    case 3:
                                        CalculateHealth();
                                        break;

                                    case 4:
                                        //Close raad data connection from DataBase
                                        reader.Close();

                                        //Add Profile management function
                                        bool continueModifying = true;

                                        while (continueModifying)
                                        {
                                            Console.WriteLine("What do you want to modify?");
                                            Console.WriteLine("1: Modify your First Name.");
                                            Console.WriteLine("2: Modify your Last Name.");
                                            Console.WriteLine("3: Modify your Weight.");
                                            Console.WriteLine("4: Modify your Activity Level.");
                                            Console.WriteLine("5: Change your Password.");
                                            Console.WriteLine("6: Exit\n");
                                            int updateNum = Convert.ToInt16(Console.ReadLine());

                                            if (updateNum == 6)
                                            {
                                                continueModifying = false;
                                                continue;
                                            }

                                            string updateQuery = "UPDATE UserInfo SET ";

                                            using (SqlCommand command1 = new SqlCommand("", sqlConnection))
                                            {
                                                switch (updateNum)
                                                {
                                                    case 1:
                                                        //Update First Name
                                                        Console.WriteLine("Enter New First Name:");
                                                        string newValue1 = Console.ReadLine();
                                                        updateQuery += "FName = @NewValue1";
                                                        command1.Parameters.AddWithValue("@NewValue1", newValue1);
                                                        break;

                                                    case 2:
                                                        //Update Last Name
                                                        Console.WriteLine("Enter New Last Name:");
                                                        string newValue2 = Console.ReadLine();
                                                        updateQuery += "LName = @NewValue2";
                                                        command1.Parameters.AddWithValue("@NewValue2", newValue2);
                                                        break;

                                                    case 3:
                                                        //Update Weight
                                                        Console.WriteLine("Enter New Weight:");
                                                        double newValue3 = Convert.ToDouble(Console.ReadLine());
                                                        updateQuery += "Weight = @NewValue3";
                                                        command1.Parameters.AddWithValue("@NewValue3", newValue3);
                                                        break;

                                                    case 4:
                                                        //Update Activity Level
                                                        Console.WriteLine("Enter New Activity Level:");
                                                        string newValue4 = Console.ReadLine();
                                                        updateQuery += "ActivityLevel = @NewValue4";
                                                        command1.Parameters.AddWithValue("@NewValue4", newValue4);
                                                        break;

                                                    case 5:
                                                        //Change Password
                                                        string UserPass = GetUserInput("Enter New Password:");
                                                        string ReUserPass = GetUserInput("Re-Enter New Password:");

                                                        //Ensure that the entered passwords match
                                                        while (UserPass != ReUserPass)
                                                        {
                                                            Console.WriteLine("Passwords do not match. Please re-enter.");
                                                            UserPass = GetUserInput("Enter New Password:");
                                                            ReUserPass = GetUserInput("Re-Enter New Password:");
                                                        }

                                                        string encryptionKey1 = "hTbHfq5rC5dAby6DJt8P3w==";
                                                        string initializationVector1 = "6mRwZNlJb/WLbCyk4n+bBg==";

                                                        var encryptionService1 = new EncryptionService(encryptionKey1, initializationVector1);

                                                        string plainText = UserPass;
                                                        string encryptedText = encryptionService1.Encrypt(plainText);

                                                        updateQuery += "Password = @encryptedText";
                                                        command1.Parameters.AddWithValue("@encryptedText", encryptedText);

                                                        break;

                                                    default:
                                                        Console.WriteLine("Invalid option.");
                                                        continue;
                                                }

                                                //Add the common part of the SQL query
                                                updateQuery += " WHERE UserName = @NUsername";
                                                command1.Parameters.AddWithValue("@NUsername", EUserName);
                                                command1.CommandText = updateQuery;

                                                //Execute the update query
                                                int rowsAffected = command1.ExecuteNonQuery();

                                                //Check how many rows were updated
                                                if (rowsAffected > 0)
                                                {
                                                    Console.WriteLine(rowsAffected + " rows updated.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No rows updated.");
                                                }

                                                Console.WriteLine("Do you want to modify another piece of data? (Y/N)");
                                                string continueResponse = Console.ReadLine().Trim().ToUpper();
                                                if (continueResponse != "Y")
                                                {
                                                    continueModifying = false;
                                                }
                                            }
                                        }

                                        break;
                                    case 5:
                                        Console.WriteLine("Exit done.");
                                        eng();
                                        break;

                                    case 6:
                                        StartProgram();
                                        break;

                                    default:
                                        Console.WriteLine("Invalid choice!, Try again");
                                        break;
                                }

                                Console.Write("\nPress any key to continue or 'q' to quit: ");

                                if (Console.ReadLine().ToLower() == "q")
                                {
                                    break;
                                }
                            }

                            void CalculateAge()
                            {
                                Console.WriteLine("\n=========================");
                                Console.WriteLine("Age Calculator Program");
                                Console.WriteLine("=========================\n");

                                //Get the birth date from the DataBase and calculate age
                                string birthDateFromDB = reader["BirthDate"].ToString();
                                DateTime birthDate = Convert.ToDateTime(birthDateFromDB);

                                DateTime now = DateTime.Now;
                                TimeSpan ageTimeSpan = now - birthDate;

                                //Calculate years, months, and days
                                int years = (int)Math.Floor(ageTimeSpan.TotalDays / 365.242199);
                                int months = (int)Math.Floor((ageTimeSpan.TotalDays % 365.242199) / 30.4368499);
                                int days = (int)Math.Floor(ageTimeSpan.TotalDays % 30.4368499);

                                //Calculate next birthday months and days
                                int nextBirthdayMonths = (int)Math.Floor(((years + 1) * 365.24199 - ageTimeSpan.TotalDays) / 30.4368499);
                                int nextBirthdayDays = (int)Math.Ceiling(((years + 1) * 365.24199 - ageTimeSpan.TotalDays) % 30.4368499);

                                //Calculate total days, hours, minutes, and seconds
                                int totalDays = (int)ageTimeSpan.TotalDays;
                                int totalHours = (int)ageTimeSpan.TotalHours;
                                Int64 totalMinutes = (Int64)ageTimeSpan.TotalMinutes;
                                Int64 Seconds = (Int64)ageTimeSpan.TotalSeconds;
                                string totalSeconds = Seconds.ToString("N0");

                                //Calculate total heartbeats
                                Int64 HeartBeats = totalMinutes * 80;
                                string totalHeartBeats = HeartBeats.ToString("N0");

                                //Calculate total food consumption in tonnes
                                double totalFoodTonnes = Math.Round((years * 675.0 / 1000.0), 3);

                                //Calculate total water consumption in liters
                                int totalWaterLitres = (int)Math.Floor(totalDays * 1.892079611964252);

                                //Calculate total years of sleep
                                double totalSleepYears = Math.Round((totalDays / 365.242199) * 0.333333333333, 2);

                                //Check if it's the user's birthday (both days and months are 0)
                                if (days == 0 && months == 0)
                                {
                                    Console.WriteLine("\nHappy Birthday <3");
                                }

                                //Display the day of the week the user was born
                                Console.WriteLine($"The day you were born is : {birthDate.DayOfWeek}");

                                //Display the user's age in years, months, and days
                                Console.WriteLine($"\nYour Age Is {years} Years & {months} Months & {days} Days.");

                                //Display the time until the next birthday in months and days
                                Console.WriteLine($"Next Birthday In {nextBirthdayMonths} Month & {nextBirthdayDays} Day");

                                //Display various facts about the user's age
                                Console.WriteLine($@"You Lived For:
{years} Years.
{months} Months.
{(int)(totalDays / 7)} Weeks.
{totalDays} Days.
{totalHours} Hours.
{totalMinutes} Minutes.
{totalSeconds} Seconds.");

                                //Display additional information about the user
                                Console.WriteLine("Amazing Facts About You…\n");
                                Console.WriteLine($"Your heart has beat for {totalHeartBeats} Times.");
                                Console.WriteLine($"You ate {totalFoodTonnes} Ton of food.");
                                Console.WriteLine($"You drank {totalWaterLitres} litres of water.");
                                Console.WriteLine($"You have slept for {totalSleepYears} Years.");


                            }

                            void CalculateDateDifference()
                            {
                                Console.WriteLine("\n=========================");
                                Console.WriteLine("Difference Between Dates Calculator\n");
                                Console.WriteLine("=========================\n");
                                Console.WriteLine("Enter Dates Like[Ex: 2000 4 16]\n");
                                DateTime firstDate, secondDate;

                                //Prompt the user to enter the first date
                                Console.WriteLine("Enter First Date: ");
                                firstDate = Convert.ToDateTime(Console.ReadLine());

                                //Prompt the user to enter the second date
                                Console.WriteLine("\nEnter Second Date: ");
                                secondDate = Convert.ToDateTime(Console.ReadLine());

                                //Calculate the time difference between the two dates
                                TimeSpan difference = firstDate - secondDate;

                                //Calculate the total number of days in the difference
                                int totalDays = (int)difference.TotalDays;

                                //Calculate the total years in the difference
                                int totalYears = (int)(totalDays / 365.242199);

                                //Calculate the remaining days after removing complete years
                                double remainingDays = totalDays % 365.242199;

                                //Calculate the total months in the remaining days
                                int totalMonths = (int)(remainingDays / 30.4368499);

                                //Calculate the remaining days after removing complete months
                                int remainingMonthsDays = (int)(remainingDays % 30.4368499);

                                //Display the calculated date difference
                                Console.WriteLine($"\nThe Difference Between The First Date And The Second Date Is…\n{totalYears} Years & {totalMonths} Months & {remainingMonthsDays} Days.");
                            }

                            void CalculateHealth()
                            {
                                Console.WriteLine("\n=========================\n");
                                Console.WriteLine("\nHealth calculations\n");
                                Console.WriteLine("\n=========================\n");
                                //Read user inputs for weight, height, age, gender, and activity level from the DataBase
                                string weightFromDB = reader["Weight"].ToString();
                                double weight = Convert.ToDouble(weightFromDB);

                                string heightFromDB = reader["Height"].ToString();
                                double height = Convert.ToDouble(heightFromDB);

                                string ageFromDB = reader["Age"].ToString();
                                int age = Convert.ToInt32(ageFromDB);

                                string genderFromDB = reader["Gender"].ToString();
                                string gender = Convert.ToString(genderFromDB);

                                string activityFromDB = reader["ActivityLevel"].ToString();
                                string activityLevel = Convert.ToString(activityFromDB);

                                //Import BMI from DataBase
                                string BMIDB = reader["BMI"].ToString();
                                double bmi = Convert.ToDouble(BMIDB);

                                //Calculate basal metabolic rate (BMR) based on gender
                                double bmr = gender == "male" ? 66 + (13.7 * weight) + (5 * height) - (6.8 * age) : 655 + (9.6 * weight) + (1.8 * height) - (4.7 * age);

                                //Calculate daily calories needs based on activity level
                                double dailyCalorieNeeds = 0;
                                switch (activityLevel)
                                {
                                    case "lazy":
                                        dailyCalorieNeeds = bmr * 1.2;
                                        break;
                                    case "lightly":
                                        dailyCalorieNeeds = bmr * 1.375;
                                        break;
                                    case "medium":
                                        dailyCalorieNeeds = bmr * 1.55;
                                        break;
                                    case "active":
                                        dailyCalorieNeeds = bmr * 1.725;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice!, Try agine");
                                        break;
                                }

                                int cal = Convert.ToInt32(dailyCalorieNeeds);

                                //Determine BMI category
                                String category = "";
                                switch (bmi)
                                {
                                    case double b when b < 18.5:
                                        category = "Underweight";
                                        break;
                                    case double b when b < 25:
                                        category = "Normal weight";
                                        break;
                                    case double b when b < 30:
                                        category = "Overweight";
                                        break;
                                    default:
                                        category = "Obesity";
                                        break;
                                }

                                //Calculate ideal weight based on gender
                                double idealWeight = gender == "male" ? height - 105 : height - 110;

                                //Display BMI and BMI category
                                Console.WriteLine("\nYour BMI Is: " + bmi);
                                Console.WriteLine("Your BMI Category Is: " + category);

                                //Display daily calories needs
                                Console.WriteLine("Your daily calorie needs are: " + cal + " calories");

                                //Display ideal weight
                                Console.WriteLine("Your Ideal Weight Is: " + idealWeight);

                                //Provide advice based on BMI category
                                if (category == "Underweight")
                                {
                                    Console.WriteLine("\nYour weight is under the minimum recommended weight. We advise you to do the following:");
                                    Console.WriteLine("\n1. Eat more meals.");
                                    Console.WriteLine("2. Drink smoothies.");
                                    Console.WriteLine("3. Monitor and avoid drinks and foods that reduce appetite.");
                                    Console.WriteLine("4. Exercise regularly.");
                                    Console.WriteLine("\nIf you do not find a result, we recommend that you see a doctor.");
                                }
                                else if (category == "Obesity")
                                {
                                    Console.WriteLine("\nYour weight is over the maximum recommended weight. We advise you to do the following:");
                                    Console.WriteLine("\n1. Exercise regularly.");
                                    Console.WriteLine("2. Follow a diet with specialist follow-up.");
                                    Console.WriteLine("3. Medicinal obesity treatment prescribed by a doctor.");
                                    Console.WriteLine("4. Surgical treatment.");
                                    Console.WriteLine("5. Do sports with the follow-up of a specialist or a professional coach.");
                                }
                                else if (category == "Overweight")
                                {
                                    Console.WriteLine("\nYour weight exceeds the recommended limit. To prevent obesity, follow the following steps:");
                                    Console.WriteLine("\n1. Eat five small meals a day.");
                                    Console.WriteLine("2. Avoid processed foods such as sausage and canned meat.");
                                    Console.WriteLine("3. Reduce your sugar consumption.");
                                    Console.WriteLine("4. Reduce the use of artificial sweeteners.");
                                    Console.WriteLine("5. Avoid saturated fats.");
                                    Console.WriteLine("6. Cook food at home.");
                                    Console.WriteLine("7. Exercise regularly.");
                                }
                                else
                                {
                                    Console.WriteLine("\nYour BMI is in the normal range. We advise you to continue to eat healthy and exercise regularly");
                                }
                            }
                        }
                        break;

                    case 2:
                        //Prompt the user for registration information
                        Console.WriteLine("Enter your first name:");
                        string Fname = Console.ReadLine();

                        Console.WriteLine("Enter your last name:");
                        string Lname = Console.ReadLine();

                        Console.WriteLine("Enter your Email:");
                        string Email = Console.ReadLine();

                        Console.WriteLine("Create a UserName:");
                        string UserName = Console.ReadLine();

                        string Password = GetUserInput("Create a Password:");
                        string rePassword = GetUserInput("Re-enter Password:");

                        //Ensure that the entered passwords match
                        while (Password != rePassword)
                        {
                            Console.WriteLine("Passwords do not match. Please re-enter.");
                            Password = GetUserInput("Create a Password:");
                            rePassword = GetUserInput("Re-enter Password:");
                        }
                        string encryptionKey = "hTbHfq5rC5dAby6DJt8P3w==";
                        string initializationVector = "6mRwZNlJb/WLbCyk4n+bBg==";

                        var encryptionService = new EncryptionService(encryptionKey, initializationVector);

                        string plainText1 = Password;
                        string encryptedText1 = encryptionService.Encrypt(plainText1);

                     
                        Console.WriteLine("Enter your BirthDate (2000 4 16):");
                        DateTime BirthDate = Convert.ToDateTime(Console.ReadLine());
                        DateTime now = DateTime.Now;
                        TimeSpan ageTimeSpan = now - BirthDate;
                        int Age = (int)Math.Floor(ageTimeSpan.TotalDays / 365.242199);

                        string gender = SelectGender();

                        Console.WriteLine("Enter your Weight (KG):");
                        int Weight = Convert.ToInt16(Console.ReadLine());

                        Console.WriteLine("Enter your Height (CM):");
                        int Height = Convert.ToInt16(Console.ReadLine());

                        string activityLevel = SelectActivity();

                        //Calculate BMI
                        double BMI = Math.Round(Weight / Math.Pow(Height / 100.0, 2), 1);

                        //Insert user data into the DataBase
                        string insertQuery = "INSERT INTO UserInfo (FName, LName, Email, UserName, Password, BirthDate, Gender, Height, Weight, Age, ActivityLevel, BMI) " +
                                             "VALUES (@Fname, @Lname, @Email, @UserName, @Password, @BirthDate, @gender, @Height, @Weight, @Age, @activityLevel, @BMI)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection))
                        {
                            insertCommand.Parameters.AddWithValue("@Fname", Fname);
                            insertCommand.Parameters.AddWithValue("@Lname", Lname);
                            insertCommand.Parameters.AddWithValue("@Email", Email);
                            insertCommand.Parameters.AddWithValue("@UserName", UserName);
                            insertCommand.Parameters.AddWithValue("@Password", encryptedText1);
                            insertCommand.Parameters.AddWithValue("@BirthDate", BirthDate);
                            insertCommand.Parameters.AddWithValue("@gender", gender);
                            insertCommand.Parameters.AddWithValue("@Height", Height);
                            insertCommand.Parameters.AddWithValue("@Weight", Weight);
                            insertCommand.Parameters.AddWithValue("@Age", Age);
                            insertCommand.Parameters.AddWithValue("@activityLevel", activityLevel);
                            insertCommand.Parameters.AddWithValue("@BMI", BMI);

                            insertCommand.ExecuteNonQuery();
                        }
                        Console.WriteLine("\n||The account has been created||\n");
                        eng();
                        break;

                    default:
                        Console.WriteLine("Invalid choice!, Try agine");
                        eng();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                eng();
            }

            //Helper method to get user input
            static string GetUserInput(string message)
            {
                Console.WriteLine(message);
                return Console.ReadLine();
            }

            //Helper method to select gender
            static string SelectGender()
            {
                while (true)
                {
                    Console.WriteLine("Enter your Gender (male/female):");
                    string gender = Console.ReadLine().ToLower();

                    if (gender == "male" || gender == "female")
                    {
                        return gender;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'male' or 'female'.");
                    }
                }
            }

            //Helper method to select activity level
            static string SelectActivity()
            {
                while (true)
                {
                    Console.WriteLine("Please enter your activity level (lazy, lightly, medium, active): ");
                    string activityLevel = Console.ReadLine().ToLower();

                    if (activityLevel == "lazy" || activityLevel == "lightly" || activityLevel == "medium" || activityLevel == "active")
                    {
                        return activityLevel;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'lazy', 'lightly', 'medium', or 'active'.");
                    }
                }
            }
        }
        static void arabic()
        {   //الاتصال بقاعدة البيانات
            System.Data.SqlClient.SqlConnection sqlConnection;
            string connectionString = @"Data Source=DESKTOP-QUB8L8T\SQLEXPRESS;Initial Catalog=UserInfoDB;Integrated Security=True";

            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                Console.WriteLine("\n1: تسجيل الدخول إلى حساب موجود\n2: إنشاء حساب جديد\n");
                Console.Write("أدخل رقم اختيارك: \n");
                int account = Convert.ToInt16(Console.ReadLine());
                switch (account)
                {
                    case 1:
                        Console.WriteLine("أدخل اسم المستخدم:");
                        string EUserName = Console.ReadLine();

                        Console.WriteLine("أدخل كلمة المرور:");
                        string EPassword = Console.ReadLine();

                        string readQuery = "SELECT * FROM UserInfo WHERE UserName = @Username";

                        using (SqlCommand command = new SqlCommand(readQuery, sqlConnection))
                        {
                            command.Parameters.AddWithValue("@Username", EUserName);

                            SqlDataReader reader = command.ExecuteReader();
                            //إضافة منطق تسجيل الدخول وقراءة البيانات من قاعدة البيانات
                            if (reader.Read())
                            {
                                string userNameFromDB = reader["UserName"].ToString();
                                string passwordFromDB = reader["Password"].ToString();

                                if (EPassword == passwordFromDB)
                                {
                                    Console.WriteLine("\nتسجيل الدخول ناجح!\n");
                                    string WlcMessage = reader["FName"].ToString();
                                    Console.WriteLine($"مرحبًا {WlcMessage}\n");
                                }
                                else
                                {
                                    Console.WriteLine("فشل تسجيل الدخول. يرجى التحقق من كلمة المرور.");
                                    arabic();
                                }
                            }
                            else
                            {
                                Console.WriteLine("فشل تسجيل الدخول. المستخدم غير موجود.");
                                arabic();
                            }
                            //إغلاق اتصال قراءة البيانات من قاعدة البيانات
                            reader.Close();
                            while (true)
                            {
                                Console.WriteLine("\n1: عرض كم عمرك بالضبط.");
                                Console.WriteLine("2: حساب الفرق بين تاريخين.");
                                Console.WriteLine("3: عرض معلومات عامة عن صحتك.\n");
                                Console.WriteLine("4: تحديث معلوماتك.");
                                Console.WriteLine("5: الخروج.");
                                Console.WriteLine("6: اختيار اللغة مرة أخرى.\n");
                                Console.Write("أدخل رقم اختيارك: \n");

                                int choice = Convert.ToInt16(Console.ReadLine());
                                switch (choice)
                                {
                                    case 1:
                                        CalculateAge();
                                        break;

                                    case 2:
                                        CalculateDateDifference();
                                        break;

                                    case 3:
                                        CalculateHealth();
                                        break;

                                    case 4:
                                        //إضافة وظيفة إدارة الملف الشخصي
                                        bool continueModifying = true;

                                        while (continueModifying)
                                        {
                                            Console.WriteLine("ماذا تريد تعديله؟");
                                            Console.WriteLine("1: تعديل الاسم الأول.");
                                            Console.WriteLine("2: تعديل الاسم الأخير.");
                                            Console.WriteLine("3: تعديل الوزن.");
                                            Console.WriteLine("4: تعديل مستوى النشاط.");
                                            Console.WriteLine("5: تغيير كلمة المرور.");
                                            Console.WriteLine("6: الخروج\n");
                                            int updateNum = Convert.ToInt16(Console.ReadLine());

                                            if (updateNum == 6)
                                            {
                                                continueModifying = false;
                                                continue;
                                            }

                                            string updateQuery = "UPDATE UserInfo SET ";

                                            using (SqlCommand command1 = new SqlCommand("", sqlConnection))
                                            {
                                                switch (updateNum)
                                                {
                                                    case 1:
                                                        //تحديث الاسم الأول
                                                        Console.WriteLine("أدخل الاسم الأول الجديد:");
                                                        string newValue1 = Console.ReadLine();
                                                        updateQuery += "FName = @NewValue1";
                                                        command1.Parameters.AddWithValue("@NewValue1", newValue1);
                                                        break;

                                                    case 2:
                                                        //تحديث الاسم الأخير
                                                        Console.WriteLine("أدخل الاسم الأخير الجديد:");
                                                        string newValue2 = Console.ReadLine();
                                                        updateQuery += "LName = @NewValue2";
                                                        command1.Parameters.AddWithValue("@NewValue2", newValue2);
                                                        break;

                                                    case 3:
                                                        //تحديث الوزن
                                                        Console.WriteLine("أدخل الوزن الجديد:");
                                                        double newValue3 = Convert.ToDouble(Console.ReadLine());
                                                        updateQuery += "Weight = @NewValue3";
                                                        command1.Parameters.AddWithValue("@NewValue3", newValue3);
                                                        break;

                                                    case 4:
                                                        //تحديث مستوى النشاط
                                                        Console.WriteLine("أدخل مستوى النشاط الجديد:");
                                                        string newValue4 = Console.ReadLine();
                                                        updateQuery += "ActivityLevel = @NewValue4";
                                                        command1.Parameters.AddWithValue("@NewValue4", newValue4);
                                                        break;

                                                    case 5:
                                                        //تغيير كلمة المرور
                                                        Console.WriteLine("أدخل كلمة المرور الجديدة:");
                                                        string newValue5 = Console.ReadLine();
                                                        Console.WriteLine("أعد ادخال كلمة المرور:");
                                                        string renewValue5 = Console.ReadLine();

                                                        updateQuery += "Password = @NewValue5";
                                                        command1.Parameters.AddWithValue("@NewValue5", newValue5);
                                                        break;

                                                    default:
                                                        Console.WriteLine("خيار غير صالح، أعد المحاولة");
                                                        continue;
                                                }

                                                //إضافة الجزء الآخر من استعلام SQL
                                                updateQuery += " WHERE UserName = @NUsername";
                                                command1.Parameters.AddWithValue("@NUsername", EUserName);
                                                command1.CommandText = updateQuery;

                                                //تنفيذ استعلام التحديث
                                                int rowsAffected = command1.ExecuteNonQuery();

                                                //التحقق من عدد الصفوف التي تم تحديثها
                                                if (rowsAffected > 0)
                                                {
                                                    Console.WriteLine(rowsAffected + " صف تم تحديثه.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("لم يتم تحديث أي صفوف.");
                                                }

                                                Console.WriteLine("هل ترغب في تعديل معلومات أخرى؟ (نعم/لا)");
                                                string continueResponse = Console.ReadLine().Trim().ToUpper();
                                                if (continueResponse != "نعم")
                                                {
                                                    continueModifying = false;
                                                }
                                            }
                                        }

                                        break;
                                    case 5:
                                        Console.WriteLine("انتهى الخروج.");
                                        break;

                                    case 6:
                                        StartProgram();
                                        break;

                                    default:
                                        Console.WriteLine("اختيار غير صالح، أعد المحاولة");
                                        break;
                                }

                                Console.Write("\nاضغط على أي مفتاح للمتابعة أو 'q' للخروج: ");

                                if (Console.ReadLine().ToLower() == "q")

                                {
                                    break;
                                }
                            }

                            void CalculateAge()
                            {
                                Console.WriteLine("\n=========================\n");
                                Console.WriteLine("\nبرنامج حاسبة العمر");
                                Console.WriteLine("\n=========================\n");

                                //الحصول على تاريخ الميلاد من قاعدة البيانات وحساب العمر
                                string birthDateFromDB = reader["BirthDate"].ToString();
                                DateTime birthDate = Convert.ToDateTime(birthDateFromDB);

                                DateTime now = DateTime.Now;
                                TimeSpan ageTimeSpan = now - birthDate;

                                //حساب السنوات والأشهر والأيام
                                int years = (int)Math.Floor(ageTimeSpan.TotalDays / 365.242199);
                                int months = (int)Math.Floor((ageTimeSpan.TotalDays % 365.242199) / 30.4368499);
                                int days = (int)Math.Floor(ageTimeSpan.TotalDays % 30.4368499);

                                //حساب شهور وأيام عيد الميلاد القادم
                                int nextBirthdayMonths = (int)Math.Floor(((years + 1) * 365.24199 - ageTimeSpan.TotalDays) / 30.4368499);
                                int nextBirthdayDays = (int)Math.Ceiling(((years + 1) * 365.24199 - ageTimeSpan.TotalDays) % 30.4368499);

                                //حساب الأيام والساعات والدقائق والثواني الإجمالية
                                int totalDays = (int)ageTimeSpan.TotalDays;
                                int totalHours = (int)ageTimeSpan.TotalHours;
                                Int64 totalMinutes = (Int64)ageTimeSpan.TotalMinutes;
                                Int64 Seconds = (Int64)ageTimeSpan.TotalSeconds;
                                string totalSeconds = Seconds.ToString("N0");

                                //حساب مجموع دقات القلب
                                Int64 HeartBeats = totalMinutes * 80;
                                string totalHeartBeats = HeartBeats.ToString("N0");

                                //حساب مجموع استهلاك الطعام بالأطنان
                                double totalFoodTonnes = Math.Round((years * 675.0 / 1000.0), 3);

                                //حساب مجموع استهلاك المياه باللتر
                                int totalWaterLitres = (int)Math.Floor(totalDays * 1.892079611964252);

                                //حساب مجموع سنوات النوم
                                double totalSleepYears = Math.Round((totalDays / 365.242199) * 0.333333333333, 2);

                                //التحقق مما إذا كان اليوم هو عيد ميلاد المستخدم (صفر الأيام والأشهر)
                                if (days == 0 && months == 0)
                                {
                                    Console.WriteLine("\nيوم ميلاد سعيد <3");
                                }

                                // عرض يوم الأسبوع الذي وُلد فيه المستخدم
                                Console.WriteLine($"اليوم الذي وُلدت فيه هو: {birthDate.DayOfWeek}");

                                // عرض عمر المستخدم بالسنوات والشهور والأيام
                                Console.WriteLine($"\nعمرك هو {years} سنة و {months} شهر و {days} يومًا.");

                                // عرض الزمن حتى العيد الميلاد التالي بالشهور والأيام
                                Console.WriteLine($"العيد الميلاد التالي في {nextBirthdayMonths} شهر و {nextBirthdayDays} يوم");

                                // عرض حقائق متنوعة حول عمر المستخدم
                                Console.WriteLine($@"لقد عشت لمدة:
{years} سنة.
{months} شهر.
{(int)(totalDays / 7)} أسبوع.
{totalDays} يوم.
{totalHours} ساعة.
{totalMinutes} دقيقة.
{totalSeconds} ثانية.");

                                // عرض معلومات إضافية حول المستخدم
                                Console.WriteLine("حقائق مذهلة عنك…\n");
                                Console.WriteLine($"قلبك قد نبض {totalHeartBeats} مرة.");
                                Console.WriteLine($"لقد أكلت {totalFoodTonnes} طن من الطعام.");
                                Console.WriteLine($"لقد شربت {totalWaterLitres} لترًا من الماء.");
                                Console.WriteLine($"لقد نمت لمدة {totalSleepYears} سنة.");


                            }

                            void CalculateDateDifference()
                            {
                                Console.WriteLine("\n=========================\n");
                                Console.WriteLine("أدخل التواريخ كالتالي [مثال: 2000 4 16]\n");
                                Console.WriteLine("\n=========================\n");
                                Console.WriteLine("Enter Dates Like[Ex: 2000 4 16]\n");
                                DateTime firstDate, secondDate;

                                // الطلب من المستخدم على إدخال التاريخ الأول
                                Console.WriteLine("أدخل التاريخ الأول: ");
                                firstDate = Convert.ToDateTime(Console.ReadLine());

                                // الطلب من المستخدم على إدخال التاريخ الثاني
                                Console.WriteLine("\nأدخل التاريخ الثاني: ");
                                secondDate = Convert.ToDateTime(Console.ReadLine());

                                // حساب الفارق الزمني بين التاريخين
                                TimeSpan difference = firstDate - secondDate;

                                // حساب الإجمالي لعدد الأيام في الفارق
                                int totalDays = (int)difference.TotalDays;

                                // حساب الإجمالي للسنوات في الفارق
                                int totalYears = (int)(totalDays / 365.242199);

                                // حساب الأيام المتبقية بعد إزالة السنوات الكاملة
                                double remainingDays = totalDays % 365.242199;

                                // حساب الإجمالي للشهور في الأيام المتبقية
                                int totalMonths = (int)(remainingDays / 30.4368499);

                                // حساب الأيام المتبقية بعد إزالة الشهور الكاملة
                                int remainingMonthsDays = (int)(remainingDays % 30.4368499);

                                // عرض فارق التاريخ المحسوب
                                Console.WriteLine($"\nالفارق بين التاريخ الأول والتاريخ الثاني هو…\n{totalYears} سنة و {totalMonths} شهر و {remainingMonthsDays} يومًا.");
                            }

                            void CalculateHealth()
                            {
                                Console.WriteLine("\n=========================\n");
                                Console.WriteLine("\nالحسابات الصحية\n");
                                Console.WriteLine("\n=========================\n");
                                // قراءة إدخالات المستخدم للوزن والطول والعمر والجنس ومستوى النشاط من قاعدة البيانات
                                string weightFromDB = reader["Weight"].ToString();
                                double weight = Convert.ToDouble(weightFromDB);

                                string heightFromDB = reader["Height"].ToString();
                                double height = Convert.ToDouble(heightFromDB);

                                string ageFromDB = reader["Age"].ToString();
                                int age = Convert.ToInt32(ageFromDB);

                                string genderFromDB = reader["Gender"].ToString();
                                string gender = Convert.ToString(genderFromDB);

                                string activityFromDB = reader["ActivityLevel"].ToString();
                                string activityLevel = Convert.ToString(activityFromDB);

                                //استيراد مؤشر كتلة الجسم من قاعدة البيانات
                                string BMIDB = reader["BMI"].ToString();
                                double bmi = Convert.ToDouble(BMIDB);

                                // حساب معدل الأيض الأساسي (BMR) استنادًا إلى الجنس
                                double bmr = gender == "male" ? 66 + (13.7 * weight) + (5 * height) - (6.8 * age) : 655 + (9.6 * weight) + (1.8 * height) - (4.7 * age);

                                // حساب السعرات الحرارية اليومية المطلوبة استنادًا إلى مستوى النشاط
                                double dailyCalorieNeeds = 0;
                                switch (activityLevel)
                                {
                                    case "lazy":
                                        dailyCalorieNeeds = bmr * 1.2;
                                        break;
                                    case "lightly":
                                        dailyCalorieNeeds = bmr * 1.375;
                                        break;
                                    case "medium":
                                        dailyCalorieNeeds = bmr * 1.55;
                                        break;
                                    case "active":
                                        dailyCalorieNeeds = bmr * 1.725;
                                        break;
                                    default:
                                        Console.WriteLine("خيار غير صالح!، حاول مرة أخرى");
                                        break;
                                }

                                int cal = Convert.ToInt32(dailyCalorieNeeds);

                                // تحديد فئة مؤشر كتلة الجسم
                                String category = "";
                                switch (bmi)
                                {
                                    case double b when b < 18.5:
                                        category = "نقص وزن";
                                        break;
                                    case double b when b < 25:
                                        category = "وزن طبيعي";
                                        break;
                                    case double b when b < 30:
                                        category = "زيادة وزن";
                                        break;
                                    default:
                                        category = "سمنة";
                                        break;
                                }

                                // حساب الوزن المثالي استنادًا إلى الجنس
                                double idealWeight = gender == "male" ? height - 105 : height - 110;

                                // عرض مؤشر كتلة الجسم والفئة
                                Console.WriteLine("\nمؤشر كتلة الجسم الخاص بك هو: " + bmi);
                                Console.WriteLine("فئة مؤشر كتلة الجسم الخاص بك هي: " + category);

                                // عرض احتياجات السعرات اليومية
                                Console.WriteLine("احتياجات السعرات اليومية الخاصة بك هي: " + cal + " سعر حراري");

                                // عرض الوزن المثالي
                                Console.WriteLine("وزنك المثالي هو: " + idealWeight);

                                // تقديم نصائح استنادًا إلى فئة مؤشر كتلة الجسم
                                if (category == "نقص وزن")
                                {
                                    Console.WriteLine("\nوزنك أقل من الحد الأدنى الموصى به. ننصحك باتباع الإرشادات التالية:");
                                    Console.WriteLine("\n1. تناول وجبات أكثر.");
                                    Console.WriteLine("2. شرب العصائر الصحية.");
                                    Console.WriteLine("3. مراقبة وتجنب المشروبات والأطعمة التي تقلل من الشهية.");
                                    Console.WriteLine("4. ممارسة التمارين بانتظام.");
                                    Console.WriteLine("\nإذا لم تجد نتيجة، نوصي بزيارة الطبيب.");
                                }
                                else if (category == "سمنة")
                                {
                                    Console.WriteLine("\nوزنك يزيد عن الحد الأقصى الموصى به. ننصحك باتباع الإرشادات التالية:");
                                    Console.WriteLine("\n1. ممارسة التمارين بانتظام.");
                                    Console.WriteLine("2. اتباع نظام غذائي بمتابعة طبية مختصة.");
                                    Console.WriteLine("3. استخدام علاج طبي لعلاج السمنة وفقًا لتوجيهات طبيب.");
                                    Console.WriteLine("4. إجراء عملية جراحية إذا اقتضت الحاجة.");
                                    Console.WriteLine("5. ممارسة الرياضة بإشراف أخصائي أو مدرب محترف.");
                                }
                                else if (category == "زيادة وزن")
                                {
                                    Console.WriteLine("\nوزنك يتجاوز الحد الأقصى الموصى به. للوقاية من السمنة، قم باتباع الخطوات التالية:");
                                    Console.WriteLine("\n1. تناول خمس وجبات صغيرة في اليوم.");
                                    Console.WriteLine("2. تجنب الأطعمة المصنعة مثل النقانق واللحوم المعلبة.");
                                    Console.WriteLine("3. قلل استهلاك السكر.");
                                    Console.WriteLine("4. تقليل استخدام المحليات الصناعية.");
                                    Console.WriteLine("5. تجنب الدهون المشبعة.");
                                    Console.WriteLine("6. طهي الطعام في المنزل.");
                                    Console.WriteLine("7. ممارسة التمارين الرياضية بانتظام.");
                                }
                                else
                                {
                                    Console.WriteLine("\nمؤشر كتلة الجسم الخاص بك في المدى الطبيعي. ننصحك بالاستمرار في تناول الطعام الصحي وممارسة الرياضة بانتظام.");
                                }
                            }
                        }
                        break;

                    case 2:
                        //إضافة منطق إنشاء حساب جديد وإدخال البيانات إلى قاعدة البيانات
                        Console.WriteLine("أدخل الاسم الأول:");
                        string Fname = Console.ReadLine();

                        Console.WriteLine("أدخل الاسم الأخير:");
                        string Lname = Console.ReadLine();

                        Console.WriteLine("أدخل بريدك الإلكتروني:");
                        string Email = Console.ReadLine();

                        Console.WriteLine("إنشئ اسم مستخدم:");
                        string UserName = Console.ReadLine();

                        string Password = GetUserInput("أنشئ كلمة مرور:");
                        string rePassword = GetUserInput("إعادة إدخال كلمة المرور:");

                        //للتأكد من تطابق كلمات المرور المدخلة
                        while (Password != rePassword)
                        {
                            Console.WriteLine("كلمة المرور غير مطابقة. الرجاء إعادة الإدخال.");
                            Password = GetUserInput("أنشئ كلمة مرور:");
                            rePassword = GetUserInput("إعادة إدخال كلمة المرور:");
                        }

                        Console.WriteLine("أدخل تاريخ ميلادك (2000 4 16):");
                        DateTime BirthDate = Convert.ToDateTime(Console.ReadLine());
                        DateTime now = DateTime.Now;
                        TimeSpan ageTimeSpan = now - BirthDate;
                        int Age = (int)Math.Floor(ageTimeSpan.TotalDays / 365.242199);

                        string gender = SelectGender();

                        Console.WriteLine("أدخل الوزن (بالكيلوغرام):");
                        int Weight = Convert.ToInt16(Console.ReadLine());

                        Console.WriteLine("أدخل الطول (بالسنتيمتر):");
                        int Height = Convert.ToInt16(Console.ReadLine());

                        string activityLevel = SelectActivity();

                        //حساب مؤشر كتلة الجسم
                        double BMI = Math.Round(Weight / Math.Pow(Height / 100.0, 2), 1);

                        //أدخال بيانات المستخدم في قاعدة البيانات
                        string insertQuery = "INSERT INTO UserInfo (FName, LName, Email, UserName, Password, BirthDate, Gender, Height, Weight, Age, ActivityLevel, BMI) " +
                                             "VALUES (@Fname, @Lname, @Email, @UserName, @Password, @BirthDate, @gender, @Height, @Weight, @Age, @activityLevel, @BMI)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection))
                        {
                            insertCommand.Parameters.AddWithValue("@Fname", Fname);
                            insertCommand.Parameters.AddWithValue("@Lname", Lname);
                            insertCommand.Parameters.AddWithValue("@Email", Email);
                            insertCommand.Parameters.AddWithValue("@UserName", UserName);
                            insertCommand.Parameters.AddWithValue("@Password", Password);
                            insertCommand.Parameters.AddWithValue("@BirthDate", BirthDate);
                            insertCommand.Parameters.AddWithValue("@gender", gender);
                            insertCommand.Parameters.AddWithValue("@Height", Height);
                            insertCommand.Parameters.AddWithValue("@Weight", Weight);
                            insertCommand.Parameters.AddWithValue("@Age", Age);
                            insertCommand.Parameters.AddWithValue("@activityLevel", activityLevel);
                            insertCommand.Parameters.AddWithValue("@BMI", BMI);

                            insertCommand.ExecuteNonQuery();
                        }

                        break;

                    default:
                        Console.WriteLine("خيار غير صالح!، حاول مرة أخرى");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("حدث خطأ: " + ex.Message);
            }

            // وظيفة للحصول على مدخلات المستخدم
            static string GetUserInput(string message)
            {
                Console.WriteLine(message);
                return Console.ReadLine();
            }

            // وظيفة لتحديد الجنس
            static string SelectGender()
            {
                while (true)
                {
                    Console.WriteLine("أدخل جنسك (ذكر/أنثى):");
                    string gender = Console.ReadLine().ToLower();

                    if (gender == "ذكر" || gender == "أنثى" || gender == "انثى")
                    {
                        if (gender == "ذكر")
                        {
                            gender = "male";
                        }
                        else if (gender == "أنثى" || gender == "انثى")
                        {
                            gender = "female";
                        }
                        return gender;
                    }
                    else
                    {
                        Console.WriteLine("إدخال غير صالح. الرجاء اختيار 'ذكر' أو 'أنثى'.");
                    }
                }
            }

            //وظيفة لتحديد مستوى النشاط
            static string SelectActivity()
            {
                while (true)
                {
                    Console.WriteLine("الرجاء إدخال مستوى نشاطك (كسول، خفيف، متوسط، نشيط): ");
                    string activityLevel = Console.ReadLine().ToLower();

                    if (activityLevel == "كسول" || activityLevel == "خفيف" || activityLevel == "متوسط" || activityLevel == "نشيط")
                    {
                        if (activityLevel == "كسول")
                        {
                            activityLevel = "lazy";
                        }
                        else if (activityLevel == "خفيف")
                        {
                            activityLevel = "lightly";
                        }
                        else if (activityLevel == "متوسط")
                        {
                            activityLevel = "medium";
                        }
                        else if (activityLevel == "نشيط")
                        {
                            activityLevel = "active";
                        }
                        return activityLevel;
                    }
                    else
                    {
                        Console.WriteLine("إدخال غير صالح. الرجاء إدخال 'كسول' أو 'خفيف' أو 'متوسط' أو 'نشيط'.");
                    }
                }
            }
        }
    }
}