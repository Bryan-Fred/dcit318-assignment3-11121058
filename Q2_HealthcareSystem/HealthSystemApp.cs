using System;
using System.Collections.Generic;
using dcit318_assignment3_11121058.Q2_HealthcareSystem.Models;

namespace dcit318_assignment3_11121058.Q2_HealthcareSystem
{
    public class HealthSystemApp
    {
        private readonly Repository<Patient> _patientRepo = new();
        private readonly Repository<Prescription> _prescriptionRepo = new();
        private readonly Dictionary<int, List<Prescription>> _prescriptionMap = new();

        // --- Required API ---

        public void SeedData()
        {
            // 2–3 Patients
            _patientRepo.Add(new Patient(1, "Brianna Manaois", 28, "Female"));
            _patientRepo.Add(new Patient(2, "Alexander Mahone", 35, "Male"));
            _patientRepo.Add(new Patient(3, "Franklin Saint", 42, "Male"));

            // 4–5 Prescriptions (valid PatientIds)
            _prescriptionRepo.Add(new Prescription(101, 1, "Amoxicillin 500mg", DateTime.Today.AddDays(-7)));
            _prescriptionRepo.Add(new Prescription(102, 1, "Ibuprofen 200mg", DateTime.Today.AddDays(-2)));
            _prescriptionRepo.Add(new Prescription(103, 2, "Paracetamol 1g", DateTime.Today.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(104, 2, "Cetirizine 10mg", DateTime.Today.AddDays(-1)));
            _prescriptionRepo.Add(new Prescription(105, 3, "Omeprazole 20mg", DateTime.Today));
        }

        public void BuildPrescriptionMap()
        {
            _prescriptionMap.Clear();

            foreach (var rx in _prescriptionRepo.GetAll())
            {
                if (!_prescriptionMap.ContainsKey(rx.PatientId))
                    _prescriptionMap[rx.PatientId] = new List<Prescription>();

                _prescriptionMap[rx.PatientId].Add(rx);
            }
        }

        public void PrintAllPatients()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== PATIENTS ===");
            Console.ResetColor();

            foreach (var p in _patientRepo.GetAll())
            {
                Console.WriteLine($"ID: {p.Id,-3}  Name: {p.Name,-18}  Age: {p.Age,-3}  Gender: {p.Gender}");
            }
            Console.WriteLine();
        }

        public List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            return _prescriptionMap.TryGetValue(patientId, out var list)
                ? new List<Prescription>(list)
                : new List<Prescription>();
        }

        public void PrintPrescriptionsForPatient(int id)
        {
            var patient = _patientRepo.GetById(p => p.Id == id);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"=== PRESCRIPTIONS FOR PATIENT ID {id} ===");
            Console.ResetColor();

            if (patient is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No such patient.\n");
                Console.ResetColor();
                return;
            }

            var rxs = GetPrescriptionsByPatientId(id);
            if (rxs.Count == 0)
            {
                Console.WriteLine($"No prescriptions found for {patient.Name}.\n");
                return;
            }

            foreach (var rx in rxs)
            {
                Console.WriteLine($"RxID: {rx.Id,-4}  Medication: {rx.MedicationName,-20}  Date: {rx.DateIssued:dd/MM/yyyy}");
            }
            Console.WriteLine();
        }

        // --- Convenience runner for Program.cs ---

        public void Run()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== HEALTHCARE SYSTEM ===\n");
            Console.ResetColor();

            SeedData();
            BuildPrescriptionMap();
            PrintAllPatients();

            Console.Write("Enter a Patient ID to view prescriptions: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var id))
            {
                Console.WriteLine();
                PrintPrescriptionsForPatient(id);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Patient ID.\n");
                Console.ResetColor();
            }

            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
    }
}
