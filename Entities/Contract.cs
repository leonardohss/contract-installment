using System;
using System.Globalization;
using System.Collections.Generic;

namespace ContractInstallment.Entities
{
    class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double TotalValue { get; set; }
        public List<Installment> Installments = new List<Installment>();

        public Contract(int number, DateTime date, double totalValue){
            Number = number;
            Date = date;
            TotalValue = totalValue;
        }

        public void AddInstallment(DateTime due, double value){
            Installments.Add(new Installment(due, value));
        }

        public override string ToString(){
            foreach (Installment installment in Installments)
            {
                Console.WriteLine(installment.DueDate.ToString("dd/MM/yyyy") 
                + " - " 
                + installment.Amount.ToString("F2", CultureInfo.InvariantCulture));
            }
            return "finish";
        }
    }
}