using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickType;
using SISL.Core.DTOs.Response;

namespace SISL.API.Constants
{
    public static class MapData
    {
        public static string Purge(this string value)
        {
            return value?.Replace("'", "").Replace("\"", "");
        }

        public static CustomerAccountDto MapAccountFormFetchData(this FetchCustomer data)
        {
            var rows = data.DataTable.Rows[0];

            var one = rows["1"];
            return new CustomerAccountDto
            {
                AccountType = rows["0"],
                Title = rows["1"],
                SureName = rows["2"],
                FirstName = rows["3"],
                OtherNames = rows["4"],
                CompName = rows["5"],
                Sex = (rows["6"].StartsWith('M') ? 1 : 2),
                DateOfBirth = DateTime.Parse(rows["7"]),
                PermanentAddress = rows["8"],
                Telephone = rows["10"],
                EmailAddress = rows["11"],
                City = rows["12"],
                State = rows["13"],
                LGA = rows["14"],
                Country = rows["15"],
                Occupation = rows["17"],
                EmploymentType = rows["19"],
                PoliticallyExposed = rows["20"],
                BVN = rows["21"],
                IdType = rows["22"],
                IdNumber = rows["23"],
                MeansOfIDExpirationDate = DateTime.Parse(rows["24"]),
                NextOfKin = rows["25"],
                ContactAddress = rows["26"],
                NextOfKinPhone = rows["27"],
                NextOfKinEmail = rows["28"],
                MeansOfIDIssueDate = DateTime.Parse(rows["29"]),
                DateOfOffice = DateTime.Parse(rows["30"]),
                PositionHeld = rows["31"],
                PoliticallyExposedPerson = rows["32"],
                MothersMaidenName = rows["33"],
                AverageAnnualIncome = rows["34"],
                SourceofInvestment = rows["35"],
                PurposeofInvestment = rows["36"],
                PEPWho = rows["37"],
                NextOfKinGender = rows["38"],
                NOKDateOfBirth = DateTime.Parse(rows["39"]),
                NOKNationality = rows["41"]
            };
        }
    }
}