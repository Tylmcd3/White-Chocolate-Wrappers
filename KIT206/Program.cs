using System;
using System.Collections.Generic;
using System.Globalization;

namespace KIT206
{
    class Program
    {
        //Driver Class
        static void Main(string[] args)
        {
            int ID = 650432; // As the user would be logged in, constantly being stored makes sense
			Student user = Storage.GetStudent(ID);
			int MainSelection = 1;
			int PersonalSelection = 1;
			int GroupSelection = 1;
			int MeetingSelection = 1;
			while (MainSelection != 0)
			{
				Console.WriteLine("Make a selection\n1.Personal Data Menu\n2.Group Menu\n3.View Upcomming meetings and classes\n0.Quit\n");
				MainSelection = Convert.ToInt32(Console.ReadLine());
				switch (MainSelection)
				{
					case 1:
						while (PersonalSelection != 0)
						{
							Console.WriteLine("Make a selection\n1.View Personal Data\n2.Add Personal Data\n0.Quit\n");
							PersonalSelection = Convert.ToInt32(Console.ReadLine());
							switch (PersonalSelection)
							{
								case 1:
									Console.WriteLine(user.ToString());
									break;
								//This hasnt been finished because the function isint implemented
								case 2:
									Console.WriteLine("Not implemented");
									break;
							}
						}
						break;
					case 2:
						while (GroupSelection != 0)
						{
							StudentGroup group = Storage.GetGroup(user.StudentGroup);
							Console.WriteLine("Make a selection\n1.Show Group Members\n2.Show Class\n3.Edit Group\n4.Meeting menu\n0.Quit\n");
							GroupSelection = Convert.ToInt32(Console.ReadLine());
							switch (GroupSelection)
							{
								case 1:
									List<Student> GroupMembers = group.GetGroupMembers();
									foreach (Student Member in GroupMembers)
									{
										Member.ToString();
									}
									break;
								case 2:
									Storage.GetClass(group.GroupID).ToString();
									break;
								case 3:
									Console.WriteLine("Enter the new name for the group");
									group.EditGroup(Console.ReadLine());
									break;
								case 4:
									while (MeetingSelection != 0)
									{
										Console.WriteLine("Make a selection\n1.View Meetings\n2.Create new Meeting\n3.Cancel Meeting\n4.Edit Meeting\n0.Quit\n");
										MeetingSelection = Convert.ToInt32(Console.ReadLine());
										switch (MeetingSelection)
										{
											case 1:

												List<Meeting> Meetings = group.GetMeetings();
												Console.WriteLine("----Meeting------");
												foreach (Meeting meeting in Meetings)
												{
													Console.WriteLine(meeting.ToString());
												}
												break;
											case 2:
												Storage.AddMeeting(group.AddMeeting());
												break;
											case 3:
												Storage.GetMeeting(group.GroupID).CancelMeeting();
												break;
											case 4:
												DateTime start, end;

												Console.WriteLine("Enter the new Start Date: HH:MM dd/mm/yyyy");
												start = DateTime.Parse(Console.ReadLine());
												Console.WriteLine("Enter the new end Date: HH:MM dd/mm/yyyy");
												end = DateTime.Parse(Console.ReadLine());
												Day day = (Day)Enum.ToObject(typeof(Day), (int)start.DayOfWeek);
												Storage.GetMeeting(group.GroupID).EditMeeting(day, start, end);
												break;
											
										}
									}
									break;
							}
						}
						break;
					case 3:
						StudentGroup UserGroup = Storage.GetGroup(user.StudentGroup);
						List<Meeting> meetings = UserGroup.GetMeetings();

						Console.WriteLine("-------Class-------");
						Console.WriteLine(Storage.GetClass(UserGroup.GroupID).ToString());
						if (meetings.Count >= 1)
						{
							Console.WriteLine("----Meeting------");
							foreach (Meeting meeting in meetings)
							{
								Console.WriteLine(meeting.ToString());
							}
						}

						break;
				}
			}
        }
    }
}
