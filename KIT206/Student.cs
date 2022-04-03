namespace KIT206
{
    public class Student
	{
		private int _studentID;
		private string _firstName;
		private string _lastName;
		private int _groupID;
		private string _title;
		private Campus _campus;
		private string _phone;
		private string _email;
		private string _photo;
		private Category _category;

		//Get data from database, maybe just take in ID? 
		public Student()
		{
			throw new System.NotImplementedException();

		}

		public StudentGroup StudentGroup
		{
			get => default;
			set
			{
			}
		}

		public void AddGroup()
		{
			throw new System.NotImplementedException();
		}

		public void AddStudentDetails()
		{
			throw new System.NotImplementedException();
		}

		public void EditStudentGroup()
		{
			throw new System.NotImplementedException();
		}
	}
}