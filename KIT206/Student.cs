namespace KIT206
{
    public class Student
	{
		private int studentID;
		private string firstName;
		private string lastName;
		private int groupID;
		private string title;
		private Campus campus;
		private string phone;
		private string email;
		private string photo;
		private Category category;

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