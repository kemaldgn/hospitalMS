using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMS
{
    class Patient
    {

        private String patientID;
        
        private String patientName;

        public Account account;

        public Patient()
        {

        }

        List<Appointment> appointments = new List<Appointment>();

        public Patient(String patientID, String username, String password, String patientName)
        {
            Account acc = new Account();

            this.account = acc;


            this.patientID = patientID;
            acc.setUsername(username);
            acc.setPassword(password);           
            this.patientName = patientName;
        }

        public void setPatientID(String patientID)
        {
            this.patientID = patientID;
        }

        public String getPatientID()
        {
            return patientID;
        }

        

        public void setPatientName(String patientName)
        {
            this.patientName = patientName;
        }

        public String getPatientName()
        {
            return patientName;
        }

        public void createAppointment(String date, Doctor doctor)
        {

            Appointment appointment = new Appointment();
            appointment.setAppointmentDate(date);
            appointments.Add(appointment);
            appointment.setAppDoctor(doctor);
            appointment.setAppPatient(this);
            
        }

        public void getAppointments()
        {
            for (int i = 0; i < appointments.Count; i++)
            {
                Console.WriteLine("Appointment date: " + appointments[i].getAppointmentDate()+ "/ Doctor Name: " + appointments[i].getAppDoctor().getName()+ "/ Patient Name: "+ appointments[i].getAppPatient().getPatientName());
            }
        }

        public List<Appointment> getApp()
        {
            return appointments;
        }

        public static void findIDFromList(List<Patient> patients)
        { 
            String patID;
            Console.WriteLine("Please enter the patient ID.");
            patID = Console.ReadLine();

            for (int i = 0; i < patients.Count; i++)
            {
                if (patID == patients[i].getPatientID())
                {
                    Console.WriteLine("Patient is founded. Now you can see the patient's informations.");
                    Console.WriteLine();
                    patients[i].printInfo();
                    break;
                }
                if (i == patients.Count - 1)
                {
                    Console.WriteLine("ID number does not match up with a patient.");
                    break;
                }
            }
        }

        public void printInfo()
        {
            Console.WriteLine("PatientID: "+ getPatientID());
            Console.WriteLine("Patient Name: " + getPatientName());
            Console.WriteLine();

        }

        public void makeAppointment(List<Doctor> doctors)
        {
            String appDoc;
            String appDate;

            Console.WriteLine("Enter a doctor name for your appointment.");
            appDoc = Console.ReadLine();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (appDoc == doctors[i].getName())
                {
                    Console.WriteLine("Doctor " + doctors[i].getName() + " is founded. Now enter a date.");
                    appDate = Console.ReadLine();

                    if(doctors[i].checkAppointmentDate(appDate)) // it means doctor is available on this date.
                    {
                        createAppointment(appDate,doctors[i]);
                        doctors[i].createAppointment(appDate,this);
                    }

                    break;
                }
                if (i == doctors.Count - 1)
                {
                    Console.WriteLine("Doctor couldn't founded. Your'e going back to menu.");
                    Console.WriteLine();
                    break;

                }
            }

        }

       

        

        
    }
}
