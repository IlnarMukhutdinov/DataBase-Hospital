using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataBase_Hospital
{
    class Doctor
    {
        [DisplayName("Код врача")]
        public int DoctorId { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string SecondName { get; set; }

        [DisplayName("Отчество")]
        public string LastName { get; set; }

        [DisplayName("Специальность")]
        public string Speciality { get; set; }

        [DisplayName("Образование")]
        public string Education { get; set; }

        [DisplayName("Пол")]
        public string Gender { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime BirthDay { get; set; }

        [DisplayName("Дата начала работы")]
        public DateTime StartDate { get; set; }

        [NotMapped]
        public Shedule Shedule { get; set; }

        [DisplayName("График работы")]
        public int SheduleId { get; set; }

        [NotMapped]
        public  List<Appointment> Appointments { get; set; }
    }

    class Patient
    {
        [DisplayName("Номер пациента")]
        public int PatientId { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string SecondName { get; set; }

        [DisplayName("Отчество")]
        public string LastName { get; set; }

        [DisplayName("Пол")]
        public string Gender { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime BirthDay { get; set; }

        [DisplayName("Номер телефона")]
        public int Phone { get; set; }

        [DisplayName("Наличие карты")]
        public bool IsHaveCard { get; set; }
        
        [NotMapped]
        public List<Appointment> Appointments { get; set; }
    }

    class Shedule
    {
        [DisplayName("Номер графика")]
        public int SheduleId { get; set; }

        [DisplayName("Рабочие дни")]
        public string WorkDays { get; set; }

        [DisplayName("Выходные дни")]
        public string Weekend { get; set; }

        [DisplayName("Примечание")]
        public string Notes { get; set; }

        [NotMapped]
        public List<Doctor> Doctors { get; set; }
    }

    class Cabinet
    {
        [DisplayName("Код кабинета")]
        public int CabinetId { get; set; }

        [DisplayName("Режим")]
        public string Shedule { get; set; }

        [DisplayName("Ответственный за кабинет")]
        public string CabinetBound { get; set; }

        [DisplayName("Номер телефона")]
        public int Phone { get; set; }

        [NotMapped]
        public List<Appointment> Appointments { get; set; }
    }

    class Appointment
    {
        [DisplayName("Номер приёма")]
        public int AppointmentId { get; set; }

        [DisplayName("Дата приёма")]
        public DateTime StartDate { get; set; }

        [DisplayName("Диагноз")]
        public string Diagnosis { get; set; }

        [DisplayName("Наличие дополнительнйо информации")]
        public bool IsExtendedInfo { get; set; }

        [DisplayName("К оплате")]
        public int Sum { get; set; }

        [DisplayName("Оплачено")]
        public bool IsPaid { get; set; }

        [NotMapped]
        public Cabinet Cabinet { get; set; }

        [DisplayName("Номер кабинета")]
        public int CabinetId { get; set; }

        [NotMapped]
        public Doctor Doctor { get; set; }

        [DisplayName("номер врача")]
        public int DoctorId { get; set; }

        [NotMapped]
        public Patient Patient { get; set; }

        [DisplayName("Номер пациента")]
        public int PatientId { get; set; }
    }
}
