using HealthMate_UI.Constants;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;

namespace HealthMate_UI
{
    public partial class HealthMonitor : Form
    {
        public HealthMonitor()
        {
            InitializeComponent();
            line.Enabled = false;
        }

        private void HealthMonitorEN_Load(object sender, EventArgs e)
        {
            double weight = CommonValues.CurrentUserInfo.Weight;
            double height = CommonValues.CurrentUserInfo.Height;
            int age = CommonValues.CurrentUserInfo.Age;
            string gender = CommonValues.CurrentUserInfo.Gender;
            string activityLevel = CommonValues.CurrentUserInfo.ActivityLevel;
            double bmi = CommonValues.CurrentUserInfo.BMI;

            float bmr = (float)(gender == "Male" ? 66 + (13.7 * weight) + (5 * height) - (6.8 * age) : 655 + (9.6 * weight) + (1.8 * height) - (4.7 * age));
            float dailyCalorieNeeds = 0;
            double idealWeight = gender == "Male" ? height - 105 : height - 110;
            if (activityLevel == "Lazy")
            {
                dailyCalorieNeeds = bmr * 1.2f;
            }
            else if (activityLevel == "Lightly")
            {
                dailyCalorieNeeds = bmr * 1.375f;
            }
            else if (activityLevel == "Medium")
            {
                dailyCalorieNeeds = bmr * 1.55f;
            }
            else if (activityLevel == "Active")
            {
                dailyCalorieNeeds = bmr * 1.725f;
            }

            // Calculate calorie needs before converting to int
            short cal = Convert.ToInt16(dailyCalorieNeeds);

            // Variables for labels and advice text
            string BMILabelText, CategoryLabelText, CalorieNeedsLabelText, IdealWeightLabelText, AdviceLabelText;

            if (CommonValues.CurrentUserInfo.IsDark)
            {
                ApplyDarkTheme();
            }
            else
            {
                ApplyLightTheme();
            }


            string category;
            if (CommonValues.CurrentUserInfo.IsArabic)
            {
                ArabicLanguage();
                if (bmi < 18.5)
                {
                    category = "نقص الوزن";
                }
                else if (bmi < 25)
                {
                    category = "وزن طبيعي";
                }
                else if (bmi < 30)
                {
                    category = "زيادة في الوزن";
                }
                else
                {
                    category = "السمنة";
                }

                BMILabelText = "مؤشر كتلة الجسم:";
                BMItxt.Text = bmi.ToString();
                CategoryLabelText = "فئة مؤشر كتلة الجسم:";
                CATEGORYtxt.Text = category;
                CalorieNeedsLabelText = "السعرات الحرارية اليومية:";
                CALORIEtxt.Text = cal.ToString() + " سعرة حرارية";
                IdealWeightLabelText = "الوزن المثالي:";
                WEIGHTtxt.Text = idealWeight.ToString() + " كغ";

                if (category == "نقص الوزن")
                {
                    AdviceLabelText = "وزنك أقل من الحد الأدنى الموصى به. ننصحك بـ:";
                    advice1.Text = "1. تناول وجبات متوازنة تحتوي على مجموعة متنوعة من العناصر الغذائية.";
                    advice2.Text = "2. تضمين وجبات خفيفة صحية مثل المكسرات والزبادي.";
                    advice3.Text = "3. إضافة الأطعمة الغنية بالبروتين مثل الدجاج واللحوم.";
                    advice4.Text = "4. حافظ على جسدك رطبًا باستخدام الماء او العصائر الطبيعية.";
                    advice5.Text = "5. المحافظة على ممارسة النشاط البدني بانتظام.";
                    advice6.Text = "6. طلب المشورة من أخصائي تغذية إذا لزم الأمر.";
                }
                else if (category == "السمنة")
                {
                    AdviceLabelText = "وزنك يتجاوز الحد الأقصى الموصى به. ننصحك بـ:";
                    advice1.Text = "1. ضع الأولوية للأطعمة الطبيعية على الخيارات المصنعة.";
                    advice2.Text = "2. إملأ نصف طبقك بالفواكه والخضروات الملونة.";
                    advice3.Text = "3. اختيار البروتينات النباتية مثل السمك والبقوليات والدواجن الخالية من الدهون.";
                    advice4.Text = "4. حافظ على نشاطك في الأنشطة التي تستمتع بها.";
                    advice5.Text = "5. ممارسة الأكل الواعي للتركيز على إشارات الجوع والشبع.";
                    advice6.Text = "6. طلب الدعم من مختص الرعاية الصحية اذا لزم الأمر.";
                }
                else if (category == "زيادة في الوزن")
                {
                    AdviceLabelText = "وزنك يتجاوز الحد الأقصى الموصى به. لتجنب السمنة، اتبع الخطوات التالية:";
                    advice1.Text = "1. تجربة تناول كميات أقل في اللقمة وتمتع بتناول الطعام ببطء.";
                    advice2.Text = "2. استبدال المشروبات الغازية بالماء.";
                    advice3.Text = "3. تضمين الأطعمة الغنية بالألياف مثل الحبوب الكاملة والبقوليات.";
                    advice4.Text = "4. المشاركة في الأنشطة البدنية الممتعة مع الأصدقاء أو العائلة.";
                    advice5.Text = "5. الحصول على قسط كاف من النوم وإدارة التوتر بتقنيات الاسترخاء.";
                    advice6.Text = "6. استشارة أخصائي تغذية للحصول على إرشادات شخصية.";
                }
                else
                {
                    AdviceLabelText = "مؤشر كتلة الجسم الخاص بك في المنطقة الصحية. للحفاظ عليه، اتبع الخطوات التالية:";
                    advice1.Text = "1. التمتع بطبق ملون مع مجموعة متنوعة من الأطعمة.";
                    advice2.Text = "2. حرك جسمك يوميًا بالأنشطة التي تحبها.";
                    advice3.Text = "3. الاستماع إلى إشارات الجوع والشبع في جسمك.";
                    advice4.Text = "4. التواصل مع الأصدقاء أو الأفراد الذين يدعمونك.";
                    advice5.Text = "5. ممارسة الامتنان والعادات الذاتية الرعاية.";
                    advice6.Text = "6. البقاء فضوليًا واستكشاف طرق جديدة لتغذية جسدك وعقلك.";
                }

            }
            else
            {
                EnglishLanguage();
                if (bmi < 18.5)
                {
                    category = "Underweight";
                }
                else if (bmi < 25)
                {
                    category = "Normal weight";
                }
                else if (bmi < 30)
                {
                    category = "Overweight";
                }
                else
                {
                    category = "Obesity";
                }

                BMILabelText = "BMI:";
                BMItxt.Text = bmi.ToString();
                CategoryLabelText = "BMI Category:";
                CATEGORYtxt.Text = category;
                CalorieNeedsLabelText = "Daily calorie needs:";
                CALORIEtxt.Text = cal.ToString() + " calories";
                IdealWeightLabelText = "Ideal Weight:";
                WEIGHTtxt.Text = idealWeight.ToString() + " KG";

                if (category == "Underweight")
                {
                    AdviceLabelText = "Your weight is under the minimum recommended weight. We advise you to:";
                    advice1.Text = "1. Enjoy balanced meals with a variety of nutrients.";
                    advice2.Text = "2. Include healthy snacks like nuts and yogurt.";
                    advice3.Text = "3. Add protein-rich foods like chicken and meat.";
                    advice4.Text = "4. Keep your body hydrated using water or natural juices.";
                    advice5.Text = "5. Maintain regular physical activity.";
                    advice6.Text = "6. Seek advice from a nutritionist if needed.";
                }
                else if (category == "Obesity")
                {
                    AdviceLabelText = "Your weight is over the maximum recommended weight. We advise you to:";
                    advice1.Text = "1. Prioritize natural foods over processed options.";
                    advice2.Text = "2. Fill half your plate with colorful fruits and vegetables.";
                    advice3.Text = "3. Choose lean proteins like fish, beans, and poultry.";
                    advice4.Text = "4. Stay active with activities you enjoy.";
                    advice5.Text = "5. Practice mindful eating to tune into hunger and fullness cues.";
                    advice6.Text = "6. Seek support from a health care professional if necessary.";
                }
                else if (category == "Overweight")
                {
                    AdviceLabelText = "Your weight exceeds the recommended limit. To prevent obesity, follow these steps:";
                    advice1.Text = "1. Try eating smaller amounts per bite and enjoy eating slowly.";
                    advice2.Text = "2. Swap sugary drinks for water.";
                    advice3.Text = "3. Include fiber-rich foods like whole grains and legumes.";
                    advice4.Text = "4. Engage in fun physical activities with friends or family.";
                    advice5.Text = "5. Get enough sleep and manage stress with relaxation techniques.";
                    advice6.Text = "6. Consult a dietitian for personalized guidance.";
                }
                else
                {
                    AdviceLabelText = "Your BMI is comfortably in the healthy zone. To maintain it:";
                    advice1.Text = "1. Enjoy a colorful plate with a variety of foods.";
                    advice2.Text = "2. Move your body daily with activities you love.";
                    advice3.Text = "3. Listen to your body's hunger and fullness signals.";
                    advice4.Text = "4. Connect with supportive friends or family members.";
                    advice5.Text = "5. Practice gratitude and self-care habits.";
                    advice6.Text = "6. Stay curious and explore new ways to nourish your body and mind.";
                }
            }

            // Update labels and textboxes on the form
            BMILabel.Text = BMILabelText;
            CategoryLabel.Text = CategoryLabelText;
            CalorieNeedsLabel.Text = CalorieNeedsLabelText;
            IdealWeightLabel.Text = IdealWeightLabelText;
            AdviceLabel.Text = AdviceLabelText;

        }

        private void HealthMonitorEN_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_MenuEN main_menuEN = new Main_MenuEN();
            main_menuEN.Show();
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(70, 70, 70);
            this.ForeColor = Color.White;
            BMILabel.ForeColor = Color.White;
            CategoryLabel.ForeColor = Color.White;
            CalorieNeedsLabel.ForeColor = Color.White;
            IdealWeightLabel.ForeColor = Color.White;
            AdviceLabel.ForeColor = Color.White;
            Back.Image = Properties.Resources.WBack;
        }

        private void ApplyLightTheme()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            BMILabel.ForeColor = Color.Black;
            CategoryLabel.ForeColor = Color.Black;
            CalorieNeedsLabel.ForeColor = Color.Black;
            IdealWeightLabel.ForeColor = Color.Black;
            AdviceLabel.ForeColor = Color.Black;
            Back.Image = Properties.Resources.Back;
        }

        private void ArabicLanguage()
        {
            base.RightToLeft = RightToLeft.Yes;
            Backlbl.Text = "رجوع";
        }

        private void EnglishLanguage()
        {
            base.RightToLeft = RightToLeft.No;
            Backlbl.Text = "Back";
        }
    }
}