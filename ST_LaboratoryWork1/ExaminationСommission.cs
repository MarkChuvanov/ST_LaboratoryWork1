using System;
using System.Collections.Generic;
using System.Linq;

namespace ST_LaboratoryWork1
{
	public class Student
	{
		public string Name { get; set; }
		public int? Mark { get; set; }
		public bool IsAdmitted { get; set; }
	}

	public class CommissionMember
	{
		public string Name { get; set; }
		public string Duty { get; set; }
	}

	public class ExaminationСommission
	{
		private List<Student> students;
		public List<Student> Students
		{
			get
			{
				return students;
			}
		}

		private List<CommissionMember> commission;
		public List<CommissionMember> Commission
		{
			get
			{
				return commission;
			}
		}

		private ExaminationСommission () { }

		public ExaminationСommission (List<Student> students, List<CommissionMember> commission)
		{
			this.students = students;
			this.commission = commission;
		}

		public int GetNumberOfAdmittedStudents ()
		{
			int count = 0;
			foreach (Student student in students)
			{
				if (student.IsAdmitted)
				{
					count++;
				}
			}
			return count;
		}

		public double GetAverageMarkOfExam ()
		{
			double amount = 0.0;
			int count = 0;
			foreach (Student student in students.Where(s => s.IsAdmitted == true))
			{
				count++;
				amount += (int)student.Mark;
			}
			return amount / count;
		}

		public int GetNumberOfAcademicDebts ()
		{
			int count = 0;
			foreach (Student student in students)
			{
				if (student.Mark == 2)
				{
					count++;
				}
			}
			return count;
		}

		public void AddStudent (Student student)
		{
			if (student == null)
			{
				throw new NullReferenceException();
			}
			students.Add(student);
		}

		public void AddMemberOfCommision (CommissionMember member)
		{
			if (member == null)
			{
				throw new NullReferenceException();
			}
			commission.Add(member);
		}

		public void RateStudent (string fullName, int rate)
		{
			if (!IsStudentExists(fullName))
			{
				throw new Exception("Такого студента не существует");
			}
			else
			{
				students.Where(s => s.Name == fullName).FirstOrDefault().Mark = rate;
			}
		}

		public bool IsStudentExists (string fullName)
		{
			return students.Exists(s => s.Name == fullName);
		}

		public bool IsCommissionMemberExists(string fullName)
		{
			return commission.Exists(m => m.Name == fullName);
		}
	}
}