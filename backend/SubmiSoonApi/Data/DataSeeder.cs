using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SubmiSoonApi.Models;
using SubmiSoonApi.Helpers;
using SubmiSoonApi.Services;

namespace SubmiSoonApi.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext db)
        {
            // Kalau sudah ada assessment, jangan seeding lagi
            if (await db.Assessments.AnyAsync())
                return;
            var passwordService = new PasswordService();
            // ===== 1. Student dummy =====
            

            // ===== 2. Assessments + Questions + Choices =====
            // 1) English Test Submission - 10 MCQ (Lorem Ipsum theme)
            var english = new Assessment
            {
                Title = "English Test Submission",
                Description = "L001 - Vivi Tricia",
                Questions = new System.Collections.Generic.List<Question>
                {
                    new Question
                    {
                        QuestionText = "What is the main purpose of using Lorem Ipsum?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "As placeholder text in design",
                            "To store passwords",
                            "To write real articles",
                            "To generate images"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Where is Lorem Ipsum commonly used?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "In UI/UX mockups and layouts",
                            "In database backups",
                            "In operating system logs",
                            "In compiler error messages"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Why do designers use Lorem Ipsum instead of real text?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "To focus on layout and typography",
                            "Because it is grammatically perfect",
                            "Because it comes from CSS",
                            "To improve server performance"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Which of the following describes Lorem Ipsum correctly?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Dummy text with no meaningful content",
                            "A real English literature text",
                            "A JavaScript framework",
                            "A database query language"
                        )
                    },
                    new Question
                    {
                        QuestionText = "From which language is the original Lorem Ipsum derived?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Latin",
                            "Spanish",
                            "French",
                            "German"
                        )
                    },
                    new Question
                    {
                        QuestionText = "What is the effect of Lorem Ipsum in a prototype design?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Avoids distraction from real content",
                            "Slows down the application",
                            "Breaks all layout rules",
                            "Automatically translates content"
                        )
                    },
                    new Question
                    {
                        QuestionText = "When should Lorem Ipsum be replaced with real content?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Before release to end users",
                            "After deployment in production",
                            "Never, it's final content",
                            "Only if a bug appears"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Which of these is NOT a good practice with Lorem Ipsum?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Keeping it in final production text",
                            "Using it in early mockups",
                            "Using it to test typography",
                            "Using it in wireframes"
                        )
                    },
                    new Question
                    {
                        QuestionText = "In an English test submission interface, Lorem Ipsum is best described as:",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Placeholder content for testing",
                            "A grammar rule in English",
                            "A type of idiom",
                            "A speaking skill"
                        )
                    },
                    new Question
                    {
                        QuestionText = "What should students focus on when they see Lorem Ipsum in an exam UI?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "The structure of the interface and question format",
                            "The deep meaning of every word",
                            "The translation of each sentence",
                            "The pronunciation of each word"
                        )
                    }
                },
                StartDate = new DateTime(2025, 11, 25, 00, 00, 00),
                EndDate = new DateTime(2025, 12, 2, 23, 59, 00)
            };

            // 2) Data Science - 5 questions
            var dataScience = new Assessment
            {
                Title = "Data Science",
                Description = "L002 - Jacob Joe",
                Questions = new System.Collections.Generic.List<Question>
                {
                    new Question
                    {
                        QuestionText = "In data science, what is 'training data'?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Data used to fit the model",
                            "Data used only for visualization",
                            "Data stored in backups",
                            "Data without any labels"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Explain in your own words what a 'feature' is in a dataset.",
                        QuestionType = QuestionType.Essay
                    },
                    new Question
                    {
                        QuestionText = "Which of the following is a supervised learning algorithm?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Linear Regression",
                            "K-Means Clustering",
                            "DBSCAN",
                            "Apriori"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Upload a small CSV dataset you have worked with before.",
                        QuestionType = QuestionType.Upload
                    },
                    new Question
                    {
                        QuestionText = "Explain the difference between overfitting and underfitting.",
                        QuestionType = QuestionType.Essay
                    }

                },
                StartDate = new DateTime(2025, 11, 25, 00, 00, 00),
                EndDate = new DateTime(2025, 12, 2, 23, 59, 00)
            };

            // 3) Calculus
            var calculus = new Assessment
            {
                Title = "Calculus",
                Description = "L003 - Yanto",
                Questions = new System.Collections.Generic.List<Question>
                {
                    new Question
                    {
                        QuestionText = "What is the derivative of x^2?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "2x",
                            "x",
                            "x^2",
                            "2"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Explain the concept of a limit in calculus.",
                        QuestionType = QuestionType.Essay
                    },
                    new Question
                    {
                        QuestionText = "What is the integral of a constant c with respect to x?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "cx + C",
                            "c",
                            "x^c + C",
                            "c/x"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Upload your handwritten solution of a derivative example.",
                        QuestionType = QuestionType.Upload
                    },
                    new Question
                    {
                        QuestionText = "Explain the difference between derivative and integral.",
                        QuestionType = QuestionType.Essay
                    }
                },
                StartDate = new DateTime(2025, 11, 25, 00, 00, 00),
                EndDate = new DateTime(2025, 12, 2, 23, 59, 00)
            };

            // 4) Physics Fundamentals
            var physics = new Assessment
            {
                Title = "Physics Fundamentals",
                Description = "L004 - Albert Tonny",
                Questions = new System.Collections.Generic.List<Question>
                {
                    new Question
                    {
                        QuestionText = "Which of the following is Newton's Third Law?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "For every action, there is an equal and opposite reaction",
                            "Force equals mass times acceleration",
                            "Energy cannot be created or destroyed",
                            "Work equals force times distance"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Define 'force' in your own words.",
                        QuestionType = QuestionType.Essay
                    },
                    new Question
                    {
                        QuestionText = "Which of the following quantities is a vector?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Velocity",
                            "Mass",
                            "Temperature",
                            "Energy"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Upload a photo of your handwritten note on basic kinematics.",
                        QuestionType = QuestionType.Upload
                    },
                    new Question
                    {
                        QuestionText = "Explain the difference between speed and velocity.",
                        QuestionType = QuestionType.Essay
                    }
                },
                StartDate = new DateTime(2025, 11, 25, 00, 00, 00),
                EndDate = new DateTime(2025, 12, 2, 23, 59, 00)
            };

            // 5) Database Design
            var databaseDesign = new Assessment
            {
                Title = "Database Design",
                Description = "L005 - Maria Lopez",
                Questions = new System.Collections.Generic.List<Question>
                {
                    new Question
                    {
                        QuestionText = "What is the main purpose of normalization?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "To reduce data redundancy",
                            "To slow down queries",
                            "To remove primary keys",
                            "To increase duplication"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Explain what a primary key is in a table.",
                        QuestionType = QuestionType.Essay
                    },
                    new Question
                    {
                        QuestionText = "Which normal form removes partial dependencies?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Second Normal Form (2NF)",
                            "First Normal Form (1NF)",
                            "Third Normal Form (3NF)",
                            "Boyce-Codd Normal Form (BCNF)"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Upload a screenshot of an ERD you have designed.",
                        QuestionType = QuestionType.Upload
                    },
                    new Question
                    {
                        QuestionText = "Explain the difference between primary key and foreign key.",
                        QuestionType = QuestionType.Essay
                    }
                },
                StartDate = new DateTime(2025, 11, 25, 00, 00, 00),
                EndDate = new DateTime(2025, 12, 2, 23, 59, 00)
            };

            // 6) Operating Systems
            var operatingSystems = new Assessment
            {
                Title = "Operating Systems",
                Description = "L006 - Henry Castle",
                Questions = new System.Collections.Generic.List<Question>
                {
                    new Question
                    {
                        QuestionText = "Which of the following is NOT an operating system?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Linux",
                            "Windows",
                            "MySQL",
                            "macOS"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Explain the role of a kernel in an operating system.",
                        QuestionType = QuestionType.Essay
                    },
                    new Question
                    {
                        QuestionText = "Which scheduling algorithm is non-preemptive?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "FCFS (First Come First Served)",
                            "Round Robin",
                            "Shortest Remaining Time",
                            "Preemptive Priority"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Upload a screenshot of your Task Manager showing running processes.",
                        QuestionType = QuestionType.Upload
                    },
                    new Question
                    {
                        QuestionText = "Explain the difference between a process and a thread.",
                        QuestionType = QuestionType.Essay
                    }
                },
                StartDate = new DateTime(2025, 11, 25, 00, 00, 00),
                EndDate = new DateTime(2025, 12, 2, 23, 59, 00)
            };

            // 7) Software Engineering
            var softwareEngineering = new Assessment
            {
                Title = "Software Engineering",
                Description = "L007 - Julia Kim",
                Questions = new System.Collections.Generic.List<Question>
                {
                    new Question
                    {
                        QuestionText = "Which of the following is a common SDLC model?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Waterfall",
                            "Bubble Sort",
                            "Depth-First Search",
                            "Binary Search"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Explain what 'requirements gathering' means in SDLC.",
                        QuestionType = QuestionType.Essay
                    },
                    new Question
                    {
                        QuestionText = "Which role is typically responsible for managing project scope and timeline?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Project Manager",
                            "Database Administrator",
                            "Network Engineer",
                            "Security Analyst"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Upload a simple software architecture diagram (can be hand-drawn).",
                        QuestionType = QuestionType.Upload
                    },
                    new Question
                    {
                        QuestionText = "Explain the difference between functional and non-functional requirements.",
                        QuestionType = QuestionType.Essay
                    }
                },
                StartDate = new DateTime(2025, 11, 25, 00, 00, 00),
                EndDate = new DateTime(2025, 12, 2, 23, 59, 00)
            };

            // 8) Machine Learning
            var machineLearning = new Assessment
            {
                Title = "Machine Learning",
                Description = "L008 - Alan Shore",
                Questions = new System.Collections.Generic.List<Question>
                {
                    new Question
                    {
                        QuestionText = "Which of the following is a supervised learning algorithm?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Decision Tree",
                            "K-Means",
                            "DBSCAN",
                            "Apriori"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Explain the difference between supervised and unsupervised learning.",
                        QuestionType = QuestionType.Essay
                    },
                    new Question
                    {
                        QuestionText = "Which technique is typically used for dimensionality reduction?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "PCA (Principal Component Analysis)",
                            "Logistic Regression",
                            "KNN",
                            "Random Forest"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Upload any notebook or script where you trained a simple ML model.",
                        QuestionType = QuestionType.Upload
                    },
                    new Question
                    {
                        QuestionText = "Explain what a loss function is and why it is important.",
                        QuestionType = QuestionType.Essay
                    }
                },
                StartDate = new DateTime(2025, 11, 25, 00, 00, 00),
                EndDate = new DateTime(2025, 12, 2, 23, 59, 00)
            };

            // 9) Cybersecurity Basics
            var cybersecurity = new Assessment
            {
                Title = "Cybersecurity Basics",
                Description = "L009 - Sarah Chen",
                Questions = new System.Collections.Generic.List<Question>
                {
                    new Question
                    {
                        QuestionText = "Which password is the strongest?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "abc123",
                            "password",
                            "Qwerty123",
                            "S$8pL#92!"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Explain what a firewall does in a network.",
                        QuestionType = QuestionType.Essay
                    },
                    new Question
                    {
                        QuestionText = "Which of these is a common social engineering attack?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Phishing",
                            "Ping flood",
                            "Port scanning",
                            "Traceroute"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Upload a screenshot or document showing basic security settings you have configured.",
                        QuestionType = QuestionType.Upload
                    },
                    new Question
                    {
                        QuestionText = "Explain the concept of 'least privilege' in access control.",
                        QuestionType = QuestionType.Essay
                    }
                },
                StartDate = new DateTime(2025, 11, 25, 00, 00, 00),
                EndDate = new DateTime(2025, 12, 2, 23, 59, 00)
            };

            // 10) Networking Basics
            var networking = new Assessment
            {
                Title = "Networking Basics",
                Description = "L010 - David Parker",
                Questions = new System.Collections.Generic.List<Question>
                {
                    new Question
                    {
                        QuestionText = "Which device is used to connect multiple networks together?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Router",
                            "Switch",
                            "Hub",
                            "Repeater"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Explain what an IP address is.",
                        QuestionType = QuestionType.Essay
                    },
                    new Question
                    {
                        QuestionText = "Which layer in the OSI model is responsible for routing?",
                        QuestionType = QuestionType.MPC,
                        Choices = ChoiceHelper.CreateChoices(
                            "Network Layer (Layer 3)",
                            "Physical Layer (Layer 1)",
                            "Session Layer (Layer 5)",
                            "Application Layer (Layer 7)"
                        )
                    },
                    new Question
                    {
                        QuestionText = "Upload a simple network diagram (can be hand-drawn).",
                        QuestionType = QuestionType.Upload
                    },
                    new Question
                    {
                        QuestionText = "Explain the difference between TCP and UDP.",
                        QuestionType = QuestionType.Essay
                    }
                },
                StartDate = new DateTime(2025, 11, 25, 00, 00, 00),
                EndDate = new DateTime(2025, 12, 2, 23, 59, 00)
            };

            // Add all assessments
            db.Assessments.AddRange(
                english,
                dataScience,
                calculus,
                physics,
                databaseDesign,
                operatingSystems,
                softwareEngineering,
                machineLearning,
                cybersecurity,
                networking
            );

            await db.SaveChangesAsync();

            // ===== 3. Set CorrectChoiceId (selalu pilihan pertama) =====
            var allMcqQuestions = await db.Questions
                .Include(q => q.Choices)
                .Where(q => q.QuestionType == QuestionType.MPC)
                .ToListAsync();

            foreach (var q in allMcqQuestions)
            {
                var firstChoice = q.Choices.OrderBy(c => c.ChoiceId).FirstOrDefault();
                if (firstChoice != null)
                {
                    q.CorrectChoiceId = firstChoice.ChoiceId;
                }
            }

            await db.SaveChangesAsync();


            // ===== Insert Students =====
            var students = new List<Student>

            {
                new Student{ Name = "Averina Nurdin", Email = "averina@gmail.com",PasswordHash = passwordService.Hash("123456")},
                new Student { Name = "Brian Lee", Email = "brian@gmail.com", PasswordHash = passwordService.Hash("123456") },
                new Student { Name = "Cynthia Tan", Email = "cynthia@gmail.com", PasswordHash = passwordService.Hash("123456") },
                new Student { Name = "Daniel Wong", Email = "daniel@gmail.com", PasswordHash = passwordService.Hash("123456") },
                new Student { Name = "Evelyn Hart", Email = "evelyn@gmail.com", PasswordHash = passwordService.Hash("123456") }
            };

            db.Students.AddRange(students);
            await db.SaveChangesAsync();

            
            var allStudents = await db.Students.ToListAsync();
            var allAssessments = await db.Assessments.ToListAsync();
            var newAttempts = new List<Attempt>();

            foreach (var stu in allStudents)
            {
                foreach (var asm in allAssessments)
                {
                    newAttempts.Add(new Attempt
                    {
                        StudentId = stu.StudentId,
                        AssessmentId = asm.AssessmentId,
                        Status = AttemptStatus.NotStarted

                    });
                }
            }

            db.Attempts.AddRange(newAttempts);
            await db.SaveChangesAsync();

            db.StudentStats.AddRange(
                new StudentStat { StudentId = 1, TotalCompleted =0, LastUpdated = DateTime.UtcNow},
                new StudentStat { StudentId = 2, TotalCompleted =0, LastUpdated = DateTime.UtcNow},
                new StudentStat { StudentId = 3, TotalCompleted =0, LastUpdated = DateTime.UtcNow},
                new StudentStat { StudentId = 4, TotalCompleted =0, LastUpdated = DateTime.UtcNow},
                new StudentStat { StudentId = 5, TotalCompleted =0, LastUpdated = DateTime.UtcNow}
            );

            await db.SaveChangesAsync();

        }
    }
}
