using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMS
{
    class Admin
    {

        public Account account; 

        public Admin(String username, String password)
        {
            Account acc = new Account();
            this.account = acc;
            acc.setUsername(username);
            acc.setPassword(password);
        }

      


        public void addDoctor(List<Doctor> doctors)
        {
            String ID;
            String name;
            String branch;
            Doctor newDoc = new Doctor();

            

            Console.WriteLine("Enter an ID for new doctor.");
            ID = Console.ReadLine();
            newDoc.setID(ID);

            Console.WriteLine("Enter a name for new doctor.");
            name = Console.ReadLine();
            newDoc.setName(name);

            Console.WriteLine("Enter your doctor's branch.");
            branch = Console.ReadLine();
            newDoc.setBranch(branch);

            if (newDoc.getBranch() != null) 
                doctors.Add(newDoc);


    }
        public void addPatient(List<Patient> patients)
        {
            String ID;
            String name;
            String username;
            String password;
            
            Patient newPatient = new Patient();

            Account acc = new Account();

            Console.WriteLine("Enter an ID for new patient.");
            ID = Console.ReadLine();
            newPatient.setPatientID(ID);

            Console.WriteLine("Enter a name for new patient.");
            name = Console.ReadLine();
            newPatient.setPatientName(name);

            Console.WriteLine("Enter an username for new patient.");
            username = Console.ReadLine();
            acc.setUsername(username);

            Console.WriteLine("Enter a password for new patient.");
            password = Console.ReadLine();
            acc.setPassword(password);

            newPatient.account = acc;

            patients.Add(newPatient);


        }

        public void removeDoctor(List<Doctor> doctors)
        {
            String name;

            int k = doctors.Count;

            Console.WriteLine("Enter the doctor name that you want to remove.");
            name = Console.ReadLine();

            for(int i=0; i < doctors.Count; i++)
            {
                if (name == doctors[i].getName())
                    doctors.RemoveAt(i);
                    Console.WriteLine("Doctor removed succesfully.");
            }

            if (k == doctors.Count)
            {
                Console.WriteLine("Doctor couldn't founded.");
            }

        }

        public void removePatient(List<Patient> patients)
        {
            String name;

            int k = patients.Count;

            Console.WriteLine("Enter the doctor name that you want to remove.");
            name = Console.ReadLine();

            for (int i = 0; i < patients.Count; i++)
            {
                if (name == patients[i].getPatientName())
                    patients.RemoveAt(i);
                Console.WriteLine("Patient removed succesfully.");
            }

            if (k == patients.Count)
            {
                Console.WriteLine("Patient couldn't founded.");
            }

        }

        public void updateDoctorInfo(List<Doctor> doctors)
        {



        }

    }
}
