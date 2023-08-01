using Microsoft.AspNetCore.Identity;
using StudentEmploymentPortalAPI.Data;
using StudentEmploymentPortalAPI.Models;
using StudentEmploymentPortalAPI.Models.DomainModels;

namespace SEP.Data
{
    public static class TaskInitializer
    {
        public static async Task<WebApplication> SeedDataAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<DataContext>();

            //Faculties
            IList<Faculty> faculties = new List<Faculty>
                {
                    new Faculty { Name = "Commerce, Law and Management" }, //1
                    new Faculty { Name = "Engineering and the Built Environment" }, //2
                    new Faculty { Name = "Health Sciences" }, //3
                    new Faculty { Name = "Humanities" }, //4
                    new Faculty { Name = "Science" } //5
                };
            foreach (var faculty in faculties)
            {
                if (!context.Faculties.Any(f => f.Name == faculty.Name))
                {
                    context.Faculties.Add(faculty);
                }
            }
            context.SaveChanges();
            // Departments
            IList<Department> departments = new List<Department>
                {
                    new Department { Name = "Accountancy", FacultyId = 1 },
                    new Department { Name = "Business Sciences", FacultyId = 1 },
                    new Department { Name = "Economics and Finance", FacultyId = 1 },
                    new Department { Name = "Law", FacultyId = 1 },
                    new Department { Name = "Wits Business School", FacultyId = 1 },
                    new Department { Name = "Wits School of Governance", FacultyId = 1 },
                    new Department { Name = "Architecture and Planning", FacultyId = 2 },
                    new Department { Name = "Civil & Environmental Engineering", FacultyId = 2 },
                    new Department { Name = "Chemical & Metallurgical Engineering", FacultyId = 2 },
                    new Department { Name = "Construction Economics & Management", FacultyId = 2 },
                    new Department { Name = "Electrical & Information Engineering", FacultyId = 2 },
                    new Department { Name = "Mechanical, Industrial & Aeronautical Engineering", FacultyId = 2 },
                    new Department { Name = "Mining Engineering", FacultyId = 2 },
                    new Department { Name = "Anatomical Sciences", FacultyId = 3 },
                    new Department { Name = "Clinical Medicine", FacultyId = 3 },
                    new Department { Name = "Oral Health Sciences", FacultyId = 3 },
                    new Department { Name = "Pathology", FacultyId = 3 },
                    new Department { Name = "Physiology", FacultyId = 3 },
                    new Department { Name = "Public Health", FacultyId = 3 },
                    new Department { Name = "Therapeutic Sciences", FacultyId = 3 },
                    new Department { Name = "Wits School of Arts", FacultyId = 4 },
                    new Department { Name = "Wits School of Education", FacultyId = 4 },
                    new Department { Name = "Human and Community Development", FacultyId = 4 },
                    new Department { Name = "Literature, Language and Media", FacultyId = 4 },
                    new Department { Name = "Social Sciences", FacultyId = 4 },
                    new Department { Name = "Animal, Plant and Environmental Sciences", FacultyId = 5 },
                    new Department { Name = "Chemistry", FacultyId = 5 },
                    new Department { Name = "Computer Science and Applied Mathematics", FacultyId = 5 },
                    new Department { Name = "Geography, Archaeology and Environmental Sciences", FacultyId = 5 },
                    new Department { Name = "Geosciences", FacultyId = 5 },
                    new Department { Name = "Mathematics", FacultyId = 5 },
                    new Department { Name = "Molecular and Cell Biology", FacultyId = 5 },
                    new Department { Name = "Physics", FacultyId = 5 },
                    new Department { Name = "Statistics and Actuarial Science", FacultyId = 5 }
                };
            foreach (var dep in departments)
            {
                if (!context.Departments.Any(d => d.Name == dep.Name))
                {
                    context.Departments.Add(dep);
                }
            }
            //Race
            IList<Race> races = new List<Race>
                {
                    new Race {Name = "Black"},
                    new Race {Name = "White"},
                    new Race {Name = "Coloured"},
                    new Race {Name = "Indian"},
                    new Race {Name = "Asian"}
                };
            foreach (var race in races)
            {
                if (!context.Races.Any(r => r.Name == race.Name))
                {
                    context.Races.Add(race);
                }
            }
            //Gender
            IList<Gender> genders = new List<Gender>
                {
                    new Gender {Name = "Male"},
                    new Gender {Name = "Female"},
                    new Gender {Name = "Prefer not to say"}
                };
            foreach (var gender in genders)
            {
                if (!context.Genders.Any(g => g.Name == gender.Name))
                {
                    context.Genders.Add(gender);
                }
            }
            //JobType
            IList<JobType> jobTypes = new List<JobType>
                {
                    new JobType {Name = "PartTime"},
                    new JobType {Name = "FullTime"}
                };
            foreach (var jobType in jobTypes)
            {
                if (!context.JobTypes.Any(j => j.Name == jobType.Name))
                {
                    context.JobTypes.Add(jobType);
                }
            }
            //BusinessType
            IList<BusinessType> businessTypes = new List<BusinessType>
                {
                    new BusinessType {Name = "Private Company (Pty.) Ltd"},
                    new BusinessType {Name = "Public Company (Ltd)"},
                    new BusinessType {Name = "Personal Liability Companies (Inc)"},
                    new BusinessType {Name = "Non-profit Company (NPC)"},
                    new BusinessType {Name = "State Owned Company (SOC Ltd)"},
                    new BusinessType {Name = "Foreiegn/External Company"}
                };
            foreach (var businessType in businessTypes)
            {
                if (!context.BusinessTypes.Any(b => b.Name == businessType.Name))
                {
                    context.BusinessTypes.Add(businessType);
                }
            }
            //DriversLicense
            IList<DriversLicense> driversLicenseCodes = new List<DriversLicense>
                {
                    new DriversLicense {Type = "Code A: Motorcycles"},
                    new DriversLicense {Type = "Code B: Light Motor Vehicles"},
                    new DriversLicense {Type = "Code C: Heavy Motor Vehicles"},
                    new DriversLicense {Type = "Code D: Combination and Articulated Vehicles"},
                    new DriversLicense {Type = "None"}                };
            foreach (var driversLicenseCode in driversLicenseCodes)
            {
                if (!context.DriversLicenses.Any(d => d.Type == driversLicenseCode.Type))
                {
                    context.DriversLicenses.Add(driversLicenseCode);
                }
            }
            //YearOfStudy
            IList<YearOfStudy> years = new List<YearOfStudy>
                {
                    new YearOfStudy {Name = "1st Year"},
                    new YearOfStudy {Name = "2nd Year"},
                    new YearOfStudy {Name = "3rd Year"},
                    new YearOfStudy {Name = "Honours"},
                    new YearOfStudy {Name = "Graduate"},
                    new YearOfStudy {Name = "Masters"},
                    new YearOfStudy {Name = "PhD"},
                    new YearOfStudy {Name = "Postdoc"},
            };
            foreach (var year in years)
            {
                if (!context.YearOfStudy.Any(y => y.Name == year.Name))
                {
                    context.YearOfStudy.Add(year);
                }
            }
            //WeekHour
            IList<WeekHour> hours = new List<WeekHour>
                {
                    new WeekHour {Range = "NA"},
                    new WeekHour {Range = "< 2"},
                    new WeekHour {Range = "2 - 4"},
                    new WeekHour {Range = "4 - 6"},
                    new WeekHour {Range = "6 - 8"},
                    new WeekHour {Range = "8 - 12"},
                    new WeekHour {Range = "> 12"},
            };
            foreach (var hour in hours)
            {
                if (!context.WeekHours.Any(h => h.Range == hour.Range))
                {
                    context.WeekHours.Add(hour);
                }
            }
            //Nationality
            IList<Nationality> nationalities = new List<Nationality>
            {
            new Nationality {Name = "Unspecified"},
            new Nationality { Name = "Afghan" },
            new Nationality { Name = "Albanian" },
            new Nationality { Name = "Algerian" },
            new Nationality { Name = "American" },
            new Nationality { Name = "Andorran" },
            new Nationality { Name = "Angolan" },
            new Nationality { Name = "Antiguans" },
            new Nationality { Name = "Argentinean" },
            new Nationality { Name = "Armenian" },
            new Nationality { Name = "Australian" },
            new Nationality { Name = "Austrian" },
            new Nationality { Name = "Azerbaijani" },
            new Nationality { Name = "Bahamian" },
            new Nationality { Name = "Bahraini" },
            new Nationality { Name = "Bangladeshi" },
            new Nationality { Name = "Barbadian" },
            new Nationality { Name = "Barbudans" },
            new Nationality { Name = "Batswana" },
            new Nationality { Name = "Belarusian" },
            new Nationality { Name = "Belgian" },
            new Nationality { Name = "Belizean" },
            new Nationality { Name = "Beninese" },
            new Nationality { Name = "Bhutanese" },
            new Nationality { Name = "Bolivian" },
            new Nationality { Name = "Bosnian" },
            new Nationality { Name = "Brazilian" },
            new Nationality { Name = "British" },
            new Nationality { Name = "Bruneian" },
            new Nationality { Name = "Bulgarian" },
            new Nationality { Name = "Burkinabe" },
            new Nationality { Name = "Burmese" },
            new Nationality { Name = "Burundian" },
            new Nationality { Name = "Cambodian" },
            new Nationality { Name = "Cameroonian" },
            new Nationality { Name = "Canadian" },
            new Nationality { Name = "Cape Verdean" },
            new Nationality { Name = "Central African" },
            new Nationality { Name = "Chadian" },
            new Nationality { Name = "Chilean" },
            new Nationality { Name = "Chinese" },
            new Nationality { Name = "Colombian" },
            new Nationality { Name = "Comoran" },
            new Nationality { Name = "Congolese" },
            new Nationality { Name = "Costa Rican" },
            new Nationality { Name = "Croatian" },
            new Nationality { Name = "Cuban" },
            new Nationality { Name = "Cypriot" },
            new Nationality { Name = "Czech" },
            new Nationality { Name = "Danish" },
            new Nationality { Name = "Djibouti" },
            new Nationality { Name = "Dominican" },
            new Nationality { Name = "Dutch" },
            new Nationality { Name = "East Timorese" },
            new Nationality { Name = "Ecuadorean" },
            new Nationality { Name = "Egyptian" },
            new Nationality { Name = "Emirian" },
            new Nationality { Name = "Equatorial Guinean" },
            new Nationality { Name = "Eritrean" },
            new Nationality { Name = "Estonian" },
            new Nationality { Name = "Ethiopian" },
            new Nationality { Name = "Fijian" },
            new Nationality { Name = "Filipino" },
            new Nationality { Name = "Finnish" },
            new Nationality { Name = "French" },
            new Nationality { Name = "Gabonese" },
            new Nationality { Name = "Gambian" },
            new Nationality { Name = "Georgian" },
            new Nationality { Name = "German" },
            new Nationality { Name = "Ghanaian" },
            new Nationality { Name = "Greek" },
            new Nationality { Name = "Grenadian" },
            new Nationality { Name = "Guatemalan" },
            new Nationality { Name = "Guinea-Bissauan" },
            new Nationality { Name = "Guinean" },
            new Nationality { Name = "Guyanese" },
            new Nationality { Name = "Haitian" },
            new Nationality { Name = "Herzegovinian" },
            new Nationality { Name = "Honduran" },
            new Nationality { Name = "Hungarian" },
            new Nationality { Name = "I-Kiribati" },
            new Nationality { Name = "Icelander" },
            new Nationality { Name = "Indian" },
            new Nationality { Name = "Indonesian" },
            new Nationality { Name = "Iranian" },
            new Nationality { Name = "Iraqi" },
            new Nationality { Name = "Irish" },
            new Nationality { Name = "Israeli" },
            new Nationality { Name = "Italian" },
            new Nationality { Name = "Ivorian" },
            new Nationality { Name = "Jamaican" },
            new Nationality { Name = "Japanese" },
            new Nationality { Name = "Jordanian" },
            new Nationality { Name = "Kazakhstani" },
            new Nationality { Name = "Kenyan" },
            new Nationality { Name = "Kittian and Nevisian" },
            new Nationality { Name = "Kuwaiti" },
            new Nationality { Name = "Kyrgyz" },
            new Nationality { Name = "Laotian" },
            new Nationality { Name = "Latvian" },
            new Nationality { Name = "Lebanese" },
            new Nationality { Name = "Liberian" },
            new Nationality { Name = "Libyan" },
            new Nationality { Name = "Liechtensteiner" },
            new Nationality { Name = "Lithuanian" },
            new Nationality { Name = "Luxembourger" },
            new Nationality { Name = "Macedonian" },
            new Nationality { Name = "Malagasy" },
            new Nationality { Name = "Malawian" },
            new Nationality { Name = "Malaysian" },
            new Nationality { Name = "Maldivian" },
            new Nationality { Name = "Malian" },
            new Nationality { Name = "Maltese" },
            new Nationality { Name = "Marshallese" },
            new Nationality { Name = "Mauritanian" },
            new Nationality { Name = "Mauritian" },
            new Nationality { Name = "Mexican" },
            new Nationality { Name = "Micronesian" },
            new Nationality { Name = "Moldovan" },
            new Nationality { Name = "Monacan" },
            new Nationality { Name = "Mongolian" },
            new Nationality { Name = "Moroccan" },
            new Nationality { Name = "Mosotho" },
            new Nationality { Name = "Motswana" },
            new Nationality { Name = "Mozambican" },
            new Nationality { Name = "Namibian" },
            new Nationality { Name = "Nauruan" },
            new Nationality { Name = "Nepalese" },
            new Nationality { Name = "New Zealander" },
            new Nationality { Name = "Ni-Vanuatu" },
            new Nationality { Name = "Nicaraguan" },
            new Nationality { Name = "Nigerian" },
            new Nationality { Name = "Nigerien" },
            new Nationality { Name = "North Korean" },
            new Nationality { Name = "Northern Irish" },
            new Nationality { Name = "Norwegian" },
            new Nationality { Name = "Omani" },
            new Nationality { Name = "Pakistani" },
            new Nationality { Name = "Palauan" },
            new Nationality { Name = "Panamanian" },
            new Nationality { Name = "Papua New Guinean" },
            new Nationality { Name = "Paraguayan" },
            new Nationality { Name = "Peruvian" },
            new Nationality { Name = "Polish" },
            new Nationality { Name = "Portuguese" },
            new Nationality { Name = "Qatari" },
            new Nationality { Name = "Romanian" },
            new Nationality { Name = "Russian" },
            new Nationality { Name = "Rwandan" },
            new Nationality { Name = "Saint Lucian" },
            new Nationality { Name = "Salvadoran" },
            new Nationality { Name = "Samoan" },
            new Nationality { Name = "San Marinese" },
            new Nationality { Name = "Sao Tomean" },
            new Nationality { Name = "Saudi" },
            new Nationality { Name = "Scottish" },
            new Nationality { Name = "Senegalese" },
            new Nationality { Name = "Serbian" },
            new Nationality { Name = "Seychellois" },
            new Nationality { Name = "Sierra Leonean" },
            new Nationality { Name = "Singaporean" },
            new Nationality { Name = "Slovakian" },
            new Nationality { Name = "Slovenian" },
            new Nationality { Name = "Solomon Islander" },
            new Nationality { Name = "Somali" },
            new Nationality { Name = "South African" },
            new Nationality { Name = "South Korean" },
            new Nationality { Name = "Spanish" },
            new Nationality { Name = "Sri Lankan" },
            new Nationality { Name = "Sudanese" },
            new Nationality { Name = "Surinamer" },
            new Nationality { Name = "Swazi" },
            new Nationality { Name = "Swedish" },
            new Nationality { Name = "Swiss" },
            new Nationality { Name = "Syrian" },
            new Nationality { Name = "Taiwanese" },
            new Nationality { Name = "Tajik" },
            new Nationality { Name = "Tanzanian" },
            new Nationality { Name = "Thai" },
            new Nationality { Name = "Togolese" },
            new Nationality { Name = "Tongan" },
            new Nationality { Name = "Trinidadian or Tobagonian" },
            new Nationality { Name = "Tunisian" },
            new Nationality { Name = "Turkish" },
            new Nationality { Name = "Tuvaluan" },
            new Nationality { Name = "Ugandan" },
            new Nationality { Name = "Ukrainian" },
            new Nationality { Name = "Uruguayan" },
            new Nationality { Name = "Uzbekistani" },
            new Nationality { Name = "Venezuelan" },
            new Nationality { Name = "Vietnamese" },
            new Nationality { Name = "Welsh" },
            new Nationality { Name = "Yemenite" },
            new Nationality { Name = "Zambian" },
            new Nationality { Name = "Zimbabwean" }
        };
            foreach (var nationality in nationalities)
            {
                if (!context.Nationalities.Any(n => n.Name == nationality.Name))
                {
                    context.Nationalities.Add(nationality);
                }
            }
            //EmployerType
            IList<EmployerType> employerTypes = new List<EmployerType>
                {
                    new EmployerType {Name = "Internal"},
                    new EmployerType {Name = "External"}
            };
            foreach (var type in employerTypes)
            {
                if (!context.EmployerTypes.Any(e => e.Name == type.Name))
                {
                    context.EmployerTypes.Add(type);
                }
            }
            //EmployerStatus
            IList<EmployerStatus> employerStatuses = new List<EmployerStatus>
                {
                    new EmployerStatus {Name = "Pending"},
                    new EmployerStatus {Name = "Approved"},
                    new EmployerStatus {Name = "Rejected"},
            };
            foreach (var status in employerStatuses)
            {
                if (!context.EmployerStatuses.Any(s => s.Name == status.Name))
                {
                    context.EmployerStatuses.Add(status);
                }
            }
            //JobPostStatus
            IList<JobPostStatus> postStatuses = new List<JobPostStatus>
                {
                    new JobPostStatus {Name = "Pending"},
                    new JobPostStatus {Name = "Approved"},
                    new JobPostStatus {Name = "Rejected"},
                    new JobPostStatus {Name = "Queried"},
                    new JobPostStatus {Name = "Withdrawn"},
            };
            foreach (var status in postStatuses)
            {
                if (!context.JobPostStatuses.Any(s => s.Name == status.Name))
                {
                    context.JobPostStatuses.Add(status);
                }
            }
            //ApplicationStatus
            IList<ApplicationStatus> appStatuses = new List<ApplicationStatus>
                {
                    new ApplicationStatus {Name = "Pending"},
                    new ApplicationStatus {Name = "On Hold"},
                    new ApplicationStatus {Name = "Interview"},
                    new ApplicationStatus {Name = "Appointed"},
                    new ApplicationStatus {Name = "Incomplete"},
                    new ApplicationStatus {Name = "Rejected"},
                    new ApplicationStatus {Name = "Cancelled"},
            };
            foreach (var appStatus in appStatuses)
            {
                if (!context.ApplicationStatuses.Any(s => s.Name == appStatus.Name))
                {
                    context.ApplicationStatuses.Add(appStatus);
                }
            }
            context.SaveChanges();

            using var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
            using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //Roles
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("User"));

            //default student
            if (userManager.FindByEmailAsync("student@sep.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    Email = "student@sep.com",
                    UserName = "student@sep.com",
                    FirstName = "Tester",
                    LastName = "one",
                    PhoneNumber = "0763253214",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };
                var result = await userManager.CreateAsync(user, "Pa$$w)ord1.");
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                    var studentId = await userManager.GetUserIdAsync(user);
                    var student = new Student
                    {
                        UserId = studentId,
                        Address = "123 Fake Street, City, Country",
                        IdNumber = "0001010299081",
                        DriversLicenseId = 1,
                        CareerObjective = "To obtain a challenging position in the IT industry.",
                        GenderId = 1,
                        RaceId = 2,
                        NationalityId = 3,
                        IsSouthAfrican = true,
                        YearOfStudyId = 1,
                        DepartmentId = 5,
                        Skills = "C#, Java, HTML, CSS",
                        Achivements = "Won coding competition 2022",
                        Interests = "Reading, Swimming, Gaming",
                    };
                    var experiences = new List<Experience>
                    {
                        new Experience
                        {
                            StudentId = studentId,
                            EmployerName = "TechCorp",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Today.AddDays(30),
                            JobTitle = "Software Developer",
                            TasksAndResponsibilities = "Developed and maintained software applications"
                        }
                    };
                    var qualifications = new List<Qualification>
                    {
                        new Qualification
                        {
                            StudentId = studentId,
                            Institution = "ABC University",
                            StartDate = new DateTime(1995, 1, 1),
                            EndDate = new DateTime(2000, 1, 1),
                            QualificationTitle = "Bachelor of Science in Computer Science",
                            Subjects = "Computer Programming, Data Structures, Algorithms",
                            Majors = "Software Engineering",
                            SubMajors = "Data Science",
                            Research = " Machine Learning in Healthcare"
                        }
                    };
                    var referees = new List<Referee>
                    {
                        new Referee
                        {
                            StudentId = studentId,
                            Name = "John Doe",
                            JobTitle = "Project Manager",
                            Insitution = "XYZ Solutions",
                            Cell = "0763263526",
                            Email = "john.doe@example.com"
                        }
                    };
                    context.Experiences.AddRange(experiences);
                    context.Qualifications.AddRange(qualifications);
                    context.Referees.AddRange(referees);
                    context.Students.Add(student);
                    context.SaveChanges();
                }
            }

            //Faker data
            var dataGenerator = scope.ServiceProvider.GetRequiredService<DataGenerator>();
            dataGenerator.GenerateFakerData();

            return app;
        }
    }
}