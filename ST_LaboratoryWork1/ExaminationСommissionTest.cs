using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ST_LaboratoryWork1
{
	[TestFixture]
	class ExaminationСommissionTest
	{
		private ExaminationСommission examinationCommission;

		[SetUp]
		public void Init ()
		{
			List<Student> students = new List<Student>()
			{
				new Student { Name = "Чуванов Марк Юрьевич", IsAdmitted = true, Mark = 5 },
				new Student { Name = "Топкин Дмитрий Михайлович", IsAdmitted = true, Mark = 2 },
				new Student{ Name = "Круглов Данила Александрович", IsAdmitted = false, Mark = null }
			};
			List<CommissionMember> commission = new List<CommissionMember>()
			{
				new CommissionMember { Name = "Привезенцев Денис Геннадьевич", Duty = "Доцент" },
				new CommissionMember { Name = "Кульков Ярослав Юрьевич", Duty = "Доцент" }
			};
			examinationCommission = new ExaminationСommission(students, commission);
		}

		[Test]
		public void GetNumberOfAdmittedStudentsTest ()
		{
			Assert.AreEqual(2, examinationCommission.GetNumberOfAdmittedStudents());
			examinationCommission.AddStudent(new Student { Name = "Наумов Антон Владимирович", IsAdmitted = true, Mark = 4 });
			Assert.AreEqual(3, examinationCommission.GetNumberOfAdmittedStudents());
		}

		[Test]
		public void GetAverageMarkOfExamTest ()
		{
			Assert.AreEqual(3.5, examinationCommission.GetAverageMarkOfExam());
			examinationCommission.AddStudent(new Student { Name = "Наумов Антон Владимирович", IsAdmitted = true, Mark = 2 });
			Assert.AreEqual(3, examinationCommission.GetAverageMarkOfExam());
		}

		[Test]
		public void GetNumberOfAcademicDebtsTest ()
		{
			Assert.AreEqual(1, examinationCommission.GetNumberOfAcademicDebts());
			examinationCommission.AddStudent(new Student { Name = "Наумов Антон Владимирович", IsAdmitted = true, Mark = 2 });
			Assert.AreEqual(2, examinationCommission.GetNumberOfAcademicDebts());
		}

		[Test]
		public void AddStudentTest ()
		{
			examinationCommission.AddStudent(new Student { Name = "Наумов Антон Владимирович", IsAdmitted = true, Mark = 2 });
			Assert.IsNotNull(examinationCommission.Students.Last());
			Assert.Throws<NullReferenceException>(() => examinationCommission.AddStudent(null));
			Assert.IsNotNull(examinationCommission.Students.Last());
		}

		[Test]
		public void AddMemberOfCommisionTest ()
		{
			examinationCommission.AddMemberOfCommision(new CommissionMember { Name = "Быков Артем Александрович", Duty = "доцент" });
			Assert.IsNotNull(examinationCommission.Commission.Last());
			Assert.Throws<NullReferenceException>(() => examinationCommission.AddMemberOfCommision(null));
			Assert.IsNull(examinationCommission.Commission.Last());
		}
	}
}