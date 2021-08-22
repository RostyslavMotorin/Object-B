﻿using Object_B.Models;
using Object_B.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Object_B.Services
{
    public class RatingTableService
    {
        public static List<RatingTable> TakeRatingTableForDB(AllDataContext context, List<RatingTable> ratTable)
        {
            var users = context.Users.ToList();
            var visitsTemp = context.Visits.ToList();

            CompareUsersService CompUsers = new CompareUsersService();



            var dateNow = DateTime.Now.ToString().Split('/');
            dateNow[2] = dateNow[2].Split(' ')[0];
            List<Visit> visits = new List<Visit>();
            for (int i = 0; i < visitsTemp.Count(); i++)
            {
                var dateVisit = visitsTemp[i].VisitTime.ToString().Split('/');
                dateVisit[2] = dateVisit[2].Split(' ')[0];
                if (dateVisit[1] == dateNow[1] && dateVisit[2] == dateNow[2])
                    visits.Add(visitsTemp[i]);
            }

            for (int j = 0; j < users.Count(); j++)
            {
                int count = 0;
                string Name = "";
                string SurName = "";
                string Email = "";
                for (int i = 0; i < visits.Count(); i++)
                {
                    Name = users[j].FirstName;
                    SurName = users[j].SecondName;
                    Email = users[j].Email;
                    if (users[j].UserId == visits[i].UserId)
                    {
                        count++;
                    }
                }
                RatingTable ratingTable = new RatingTable();
                ratingTable.Position = count;
                ratingTable.Name = Name;
                ratingTable.SurName = SurName;
                ratingTable.Email = Email;
                ratTable.Add(ratingTable);
            }
            ratTable.Sort(CompUsers);
            return ratTable;
        }
    }
}
