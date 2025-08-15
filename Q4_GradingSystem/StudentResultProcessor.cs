using System;
using System.Collections.Generic;
using System.IO;
using dcit318_assignment3_11121058.Q4_GradingSystem.Models;
using dcit318_assignment3_11121058.Q4_GradingSystem.Exceptions;

namespace dcit318_assignment3_11121058.Q4_GradingSystem
{
    public class StudentResultProcessor
    {
        public (List<Student> validStudents, List<string> errors) ReadStudentsFromFile(string inputFileName)
        {
            var students = new List<Student>();
            var errors = new List<string>();

            string inputFilePath = Path.Combine(GetProjectRootPath(), inputFileName);

            if (!File.Exists(inputFilePath))
                throw new FileNotFoundException($"Input file not found at {inputFilePath}");

            using (var reader = new StreamReader(inputFilePath))
            {
                string? line;
                int lineNumber = 1;

                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        lineNumber++;
                        continue;
                    }

                    var parts = line.Split(',');

                    try
                    {
                        if (parts.Length < 3)
                            throw new RecordMissingFieldException($"Line {lineNumber}: Missing fields (expected 3 values).");

                        if (!int.TryParse(parts[0].Trim(), out int id))
                            throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid ID format.");

                        string fullName = parts[1].Trim();

                        if (!int.TryParse(parts[2].Trim(), out int score))
                            throw new InvalidScoreFormatException($"Line {lineNumber}: Score is not a valid number.");

                        students.Add(new Student(id, fullName, score));
                    }
                    catch (Exception ex)
                    {
                        errors.Add(ex.Message);
                    }

                    lineNumber++;
                }
            }

            return (students, errors);
        }

        public void WriteReportToFile(List<Student> students, string outputFileName)
        {
            string outputFilePath = Path.Combine(GetProjectRootPath(), outputFileName);

            using (var writer = new StreamWriter(outputFilePath))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}");
                }
            }
        }

        private string GetProjectRootPath()
        {
            // Go up 3 levels from bin/Debug/netX.X to the project root
            return Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
        }
    }
}
