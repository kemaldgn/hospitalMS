using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMS
{
    class Appointment
    {

        private String appointmentDate;

        private Doctor appDoctor;
        private Patient appPatient;

        public void setAppointmentDate(String appointmentDate)
        {
            this.appointmentDate = appointmentDate;
        }

        public String getAppointmentDate()
        {
            return appointmentDate;
        }

        public void setAppDoctor(Doctor appDoctor)
        {
            this.appDoctor = appDoctor;
        }

        public Doctor getAppDoctor()
        {
            return appDoctor;
        }

        public void setAppPatient(Patient appPatient)
        {
            this.appPatient = appPatient;
        }

        public Patient getAppPatient()
        {
            return appPatient;
        }

    }
}
