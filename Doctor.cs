using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMS
{
    class Doctor
    {

        private String ID;
        private String name;
        private String branch;
        private int appointmentNumber;

        
        List<Appointment> appointments = new List<Appointment>(); 

        public Doctor()
        {

        }

        public Doctor(String ID, String name, String branch)
        {
            this.ID = ID;
            this.name = name;
            setBranch(branch);
           
        }

        public void setID(String ID)
        {
            this.ID = ID;
        }

        public String getID()
        {
            return ID;
        }

        public void setAppointmentNumber(int appointmentNumber)
        {
            this.appointmentNumber = appointmentNumber;
        }

        public int getAppointmentNumber()
        {
            return appointmentNumber;
        }


        public void setName(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return name;
        }

        public void setBranch(String branch)
        {
            if (string.Equals(branch, "Eye diseases"))
                this.branch = branch;

            else if (string.Equals(branch, "Cardiovascular Surgery"))
                this.branch = branch;

            else if (string.Equals(branch, "Mental Health and Diseases"))
                this.branch = branch;

            else if (string.Equals(branch, "Neurology"))
                this.branch = branch;

            else
                Console.WriteLine("This is not valid branch for a doctor!!");

        }
        
        public String getBranch()
        {
            return branch;
        }

        public void createAppointment(String date, Patient patient)
        {
            
            Appointment appointment = new Appointment();
            appointment.setAppointmentDate(date);
            appointments.Add(appointment);
            appointment.setAppPatient(patient);
            appointmentNumber++;
        }

        public void printAppointments()
        {
            for(int i=0; i<appointments.Count; i++)
            {
               Console.WriteLine("Appointment date: "+ appointments[i].getAppointmentDate()+"/ Patient Name: "+ appointments[i].getAppPatient().getPatientName());
                
            }
        }

        public bool checkAppointmentDate(String date)
        {
            for(int a=0; a<appointments.Count; a++)
            {

                if(date == appointments[a].getAppointmentDate()) { // it means appointment date is not available.

                    Console.WriteLine("Doctor is not avaiable on this date.");
                    return false;
                
                }

            }

            return true;
        }
        

        public static void findIDFromList(List<Doctor> doctors)
        {
            String docID;
            Console.WriteLine("Please enter the doctor ID.");
            docID = Console.ReadLine();

            for (int i = 0; i < doctors.Count; i++)
            {
                if (docID == doctors[i].getID())
                {
                    Console.WriteLine("Doctor is founded. Now you can see the doctor's informations.");
                    Console.WriteLine();
                    doctors[i].printInfo();
                    break;
                }
                if (i == doctors.Count - 1)
                {
                    Console.WriteLine("ID number does not match up with a doctor.");
                    break;
                }
            }
        }

        public static Doctor findWithIDFromListToChange(List<Doctor> doctors)
        {
            String docID;
            Console.WriteLine("Please enter the doctor ID.");
            docID = Console.ReadLine();

            for (int i = 0; i < doctors.Count; i++)
            {
                if (docID == doctors[i].getID())
                {
                    Console.WriteLine("Doctor is founded. Now you can see the doctor's informations.");
                    Console.WriteLine();
                    doctors[i].printInfo();
                    return doctors[i];
                    
                }
                if (i == doctors.Count - 1)
                {
                    Console.WriteLine("ID number does not match up with a doctor.");
                    return null;
                }
            }
            return null;
        }


        public static void findBranchFromList(List<Doctor> doctors)
        {
            String docBranch;
            docBranch = Console.ReadLine();

            for (int i = 0; i < doctors.Count; i++)
            {
                if (docBranch == doctors[i].getBranch())
                {
                    doctors[i].printInfo();
                }
            }
        }

        public void printInfo()
        {
            Console.WriteLine("Doctor ID: "+ getID());
            Console.WriteLine("Doctor Name: " + getName());
            Console.WriteLine("Doctor Branch: " + getBranch());
            Console.WriteLine("Appointments of the doctor: ");
            printAppointments();
            Console.WriteLine();

        }

        

    }
}
