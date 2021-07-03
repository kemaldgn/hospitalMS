using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HospitalMS
{
    class Test
    {

        public static void Display(List<Doctor> doctors, List<Patient> patients, Admin admin)
        {

            String file_path = @"C:\texts\doctors.txt";



            String file_path3 = @"C:\texts\patientAppInfo.txt";



            List<string> output = new List<string>(); // for the writing doctor infos to text file.

            List<string> apps = new List<string>();

            String userc;
            bool program = true;
            bool enterance = true;
            bool enteranceA = true;



            String usernamec;
            String password;

            bool entered = false;
            bool enteredA = false;

            int contr = 0;

            String choice;

            String ID;

            int k = 0;



            while (program)
            {

                Console.WriteLine("*** Welcome to the our Hospital ***");
                Console.WriteLine("Press 1 to access as an Admin. ");
                Console.WriteLine("Press 2 to enter the system as a patient..");
                Console.WriteLine("Press 0 to shut the system down.");
                userc = Console.ReadLine();
                switch (userc)
                {
                    case "0":

                        program = false;

                        break;


                    case "1":
                        while (enteranceA)
                        {
                            Console.WriteLine("Please enter your username press enter and than enter your password.");
                            usernamec = Console.ReadLine();
                            password = Console.ReadLine();

                            if (usernamec == admin.account.getUsername()) // then control the password.
                            {
                                if (password == admin.account.getPassword())
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Welcome to the Admin menu.");
                                    Console.WriteLine("You entered successfully to the system.");

                                    Console.WriteLine();
                                    enteredA = true;
                                    enteranceA = false;


                                }
                            }

                            if (enteredA == false)
                            {
                                Console.WriteLine("Wrong password or ID");
                                Console.WriteLine("Press 0 to exit from system.");
                                Console.WriteLine("Press 1 to try to enter again.");
                                userc = Console.ReadLine();
                                switch (userc)
                                {
                                    case "0":
                                        enteranceA = false;
                                        program = false;
                                        break;

                                    case "1":

                                        break;

                                    default:
                                        Console.WriteLine("Invalid input !");
                                        break;
                                }

                            }

                            while (enteredA)
                            {
                                Console.WriteLine("Enter -1 to go back to main menu.");
                                Console.WriteLine("Press 0 to exit from system.");
                                Console.WriteLine("Press 1 load all doctors info.");
                                Console.WriteLine("Press 2 add a new doctor/patient.");
                                Console.WriteLine("Press 3 remove a doctor/patient.");
                                Console.WriteLine("Press 4 to search and display patient info.");
                                Console.WriteLine("Press 5 update a doctor info with his ID.");
                                Console.WriteLine("Press 6 to update a patient's info with name.");
                                Console.WriteLine("Press 7 to list all patient's info.");
                                Console.WriteLine("Press 8 to search for a patient with ID.");
                                Console.WriteLine("Press 9 display all doctors info.");
                                Console.WriteLine("Press 10 to display all appointments.");
                                Console.WriteLine();
                                userc = Console.ReadLine();

                                switch (userc)
                                {

                                    case "-1":

                                        enteredA = false;
                                        enteranceA = false;
                                        enterance = true;


                                        break;


                                    case "0":

                                        program = false;
                                        enteredA = false;

                                        break;

                                    case "1":

                                        List<string> lines = System.IO.File.ReadAllLines(file_path).ToList();

                                        foreach (var line in lines)
                                        {
                                            String[] entries = line.Split(',');

                                            Doctor newDoc = new Doctor();

                                            newDoc.setID(entries[0]);
                                            newDoc.setName(entries[1]);
                                            newDoc.setBranch(entries[2]);

                                            doctors.Add(newDoc);

                                        }

                                        break;

                                    case "2":
                                        Console.WriteLine("Press 1 to add a new doctor.");
                                        Console.WriteLine("Press 2 to add a new patient.");
                                        choice = Console.ReadLine();
                                        if (choice == "1")
                                            admin.addDoctor(doctors);

                                        if (choice == "2")
                                            admin.addPatient(patients);



                                        break;

                                    case "3":
                                        Console.WriteLine("Press 1 to remove a doctor.");
                                        Console.WriteLine("Press 2 to remove a patient.");
                                        choice = Console.ReadLine();
                                        if (choice == "1")
                                            admin.removeDoctor(doctors);

                                        if (choice == "2")
                                            admin.removePatient(patients);

                                        else
                                            Console.WriteLine("Invalid input.");

                                        break;
                                    case "4":
                                        Console.WriteLine("Press 1 to display a doctor info.");
                                        Console.WriteLine("Press 2 to display a patient info.");
                                        choice = Console.ReadLine();
                                        if (choice == "1")
                                            Doctor.findIDFromList(doctors);

                                        if (choice == "2")
                                            Patient.findIDFromList(patients);

                                        else
                                            Console.WriteLine("Invalid input.");


                                        break;

                                    case "5":
                                        Console.WriteLine("Warn: You cannot change the ID of a doctor!");

                                        String newName;
                                        String newBranch;

                                        Console.WriteLine("Enter an ID for doctor.");
                                        ID = Console.ReadLine();


                                        for (int i = 0; i < doctors.Count; i++)
                                        {

                                            if (ID == doctors[i].getID())
                                            {
                                                Console.WriteLine("You found the doctor " + doctors[i].getName());

                                                Console.WriteLine("Press 1 to change Name, Press 2 to change branch");
                                                choice = Console.ReadLine();

                                                Console.WriteLine();

                                                if (choice == "1")
                                                {
                                                    Console.WriteLine("Enter a name.");
                                                    newName = Console.ReadLine();
                                                    doctors[i].setName(newName);


                                                }

                                                else if (choice == "2")
                                                {
                                                    Console.WriteLine("Enter a branch.");
                                                    newBranch = Console.ReadLine();
                                                    doctors[i].setBranch(newBranch);
                                                }

                                                else
                                                {
                                                    Console.WriteLine("Invalid input!");
                                                }
                                            }
                                        }

                                        break;

                                    case "6":

                                        String newUsername;
                                        String newPassword;
                                        Console.WriteLine("Enter an ID for patient.");
                                        ID = Console.ReadLine();


                                        for (int i = 0; i < patients.Count; i++)
                                        {

                                            if (ID == patients[i].getPatientID())
                                            {
                                                Console.WriteLine("You found the doctor " + patients[i].getPatientName());

                                                Console.WriteLine("Press 1 to change Name, Press 2 to change username, Press 3 to change password");
                                                choice = Console.ReadLine();

                                                Console.WriteLine();

                                                if (choice == "1")
                                                {
                                                    Console.WriteLine("Enter a name.");
                                                    newName = Console.ReadLine();
                                                    patients[i].setPatientName(newName);
                                                }

                                                else if (choice == "2")
                                                {
                                                    Console.WriteLine("Enter a username.");
                                                    newUsername = Console.ReadLine();
                                                    patients[i].account.setUsername(newUsername);
                                                }

                                                else if (choice == "3")
                                                {
                                                    Console.WriteLine("Enter a password.");
                                                    newPassword = Console.ReadLine();
                                                    patients[i].account.setPassword(newPassword);
                                                }

                                                else
                                                {
                                                    Console.WriteLine("Invalid input!");
                                                }
                                            }
                                        }


                                        break;

                                    case "7":

                                        for (int i = 0; i < patients.Count; i++)
                                        {
                                            patients[i].printInfo();
                                        }


                                        break;

                                    case "8":

                                        Patient.findIDFromList(patients);


                                        break;

                                    case "9":
                                        for (int i = 0; i < doctors.Count; i++)
                                        {
                                            doctors[i].printInfo();
                                        }     
                                            

                                            foreach (var doctor in doctors)
                                            {

                                                output.Add($"{doctor.getID()},{doctor.getName()},{doctor.getBranch()}");

                                            }
                                            Console.WriteLine("Writing to text file 'doctors.txt'. ");

                                            System.IO.File.WriteAllLines(file_path, output);

                                            Console.WriteLine("All entries written to doctors.txt .");
                                        
                                        

                                        break;

                                    case "10":

                                        
                                        int appcount = 0;
                                        for (int i = 0; i < patients.Count; i++)
                                        {
                                            appcount++;
                                            patients[i].getAppointments();
                                        }

                                        Console.WriteLine("Appointment count: " + appcount);
                                        Console.WriteLine();

                                        break;


                                    default:
                                        Console.WriteLine("Invalid input !");
                                        break;
                                }

                            }

                            //

                        }

                        break;

                    case "2":

                        while (enterance)
                        {
                            Console.WriteLine("Please enter your username press enter and than enter your password.");
                            usernamec = Console.ReadLine();
                            password = Console.ReadLine();
                            for (int i = 0; i < patients.Count; i++)
                            {
                                if (usernamec == patients[i].account.getUsername()) // then control the password.
                                {
                                    if (password == patients[i].account.getPassword())
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Welcome " + patients[i].getPatientName());
                                        Console.WriteLine("You entered successfully to the system.");
                                        k = i;
                                        Console.WriteLine();
                                        entered = true;
                                        enterance = false;
                                        break;

                                    }
                                }
                            }

                            if (entered == false)
                            {
                                Console.WriteLine("Wrong password or ID");
                                Console.WriteLine("Press 0 to exit from system.");
                                Console.WriteLine("Press 1 to try to enter again.");
                                userc = Console.ReadLine();
                                switch (userc)
                                {
                                    case "0":
                                        enterance = false;
                                        program = false;
                                        break;

                                    case "1":

                                        break;

                                    default:
                                        Console.WriteLine("Invalid input !");
                                        break;

                                }
                            }
                        }
                        while (entered)
                        {




                            Console.WriteLine("Enter -1 to go back to main menu.");
                            Console.WriteLine("Press 0 to exit from system.");
                            Console.WriteLine("Press 1 to make a new appointment with doctor name that you want.");
                            Console.WriteLine("Press 2 to see appointments made by you(also write the appointments to file).");
                            Console.WriteLine("Press 3 to search for a specific doctor with branch or ID.");

                            Console.WriteLine();

                            userc = Console.ReadLine();
                            switch (userc)
                            {
                                case "-1":

                                    entered = false;
                                    enteranceA = true;

                                    break;

                                case "0":

                                    program = false;
                                    entered = false;
                                    break;

                                case "1":

                                    patients[k].makeAppointment(doctors);

                                    break;


                                case "2":

                                    patients[k].getAppointments();

                                    foreach (var appointment in patients[k].getApp())
                                    {
                                        apps.Add($"{"Date: " + appointment.getAppointmentDate()},{"/ Doctor: " + appointment.getAppDoctor()},{"/ Patient:" + appointment.getAppPatient()}");
                                    }
                                    Console.WriteLine("Writing to text file 'patientAppInfo.txt'");

                                    System.IO.File.WriteAllLines(file_path3, apps);

                                    Console.WriteLine("All entries weitten to patientAppInfo.");

                                    Console.WriteLine();

                                    break;


                                case "3":
                                    Console.WriteLine("Press 1 to search a doctor with ID and enter an ID.");
                                    Console.WriteLine("Press 2 to search a doctor with branch and enter a branch.");
                                    userc = Console.ReadLine();
                                    switch (userc)
                                    {
                                        case "1":

                                            Doctor.findIDFromList(doctors);

                                            break;

                                        case "2":

                                            Doctor.findBranchFromList(doctors);

                                            break;

                                        default:
                                            Console.WriteLine("Invalid input !");
                                            break;
                                    }

                                    break;

                                default:
                                    Console.WriteLine("Invalid input !");
                                    break;

                            }
                        }



                        break;

                    default:

                        Console.WriteLine("Invalid input!");

                        break;


                }

                
            }
        }

        static void Main(string[] args)
        {

            Admin admin = new Admin("admin","0000");

            

            Patient pat1 = new Patient("001","hsn123","123","Hassan");
            Patient pat2 = new Patient("002", "mlk123", "025", "Melek");
            Patient pat3 = new Patient("003", "ucn123", "352", "Ucbi");
            Patient pat4 = new Patient("004", "hsn123", "700", "Hassan");
            Patient pat5 = new Patient("005", "hsn123", "142", "Ilker");
            Patient pat6 = new Patient("006", "hsn123", "242", "Namık");
            Patient pat7 = new Patient("007", "hsn123", "198", "Momba");
            Patient pat8 = new Patient("008", "hsn123", "005", "Kopf");
            Patient pat9 = new Patient("009", "hsn123", "258", "Durfen");



            List<Doctor> doctors = new List<Doctor>();
           

            List<Patient> patients = new List<Patient>();
            patients.Add(pat1);
            patients.Add(pat2);
            patients.Add(pat3);
            patients.Add(pat4);
            patients.Add(pat5);
            patients.Add(pat6);
            patients.Add(pat7);
            patients.Add(pat8);
            patients.Add(pat9);

            Display(doctors,patients,admin);
            





        }
    }
}
