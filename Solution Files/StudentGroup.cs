using System;
using System.Collections.Generic;

namespace KIT206
{
    public class StudentGroup
    {
        //Private Fields
        private int _groupID;
        private string _groupName;


        //Public properties
        public int GroupID
        {
            get
            {
                return _groupID;
            }
            set
            {
                _groupID = value;
            }
        }
        public string GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
            }
        }
        //either generates a number and checks it doesnt exists or find the next sequential one
        public StudentGroup(string name)
        {
            //Generate group ID and then set to groupID (5 is placeholder)

            _groupID = GenerateGroupID();
            _groupName = name;
        }
        public StudentGroup(int id, string name)
        {
            //Generate group ID and then set to groupID (5 is placeholder)

            _groupID = id;
            _groupName = name;
        }
        private int GenerateGroupID()
        {
            int id;
            do
            {
                id = (int)(DateTime.Now.Ticks % 1000000);
            } while (false);
            return id;
        }
       
    }
}