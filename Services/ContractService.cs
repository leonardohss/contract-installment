using System;
using System.Globalization;
using ContractInstallment.Entities;

namespace ContractInstallment.Services
{
    class ContractService
    {
         private IOnlinePaymentService _onlinePaymentService;

         public ContractService(IOnlinePaymentService onlinePaymentService){
             _onlinePaymentService = onlinePaymentService;
         }

         public void ProcessContract(Contract contract, int months){
             DateTime due = contract.Date;
             double value = contract.TotalValue / months;

             for(int x = 1; x <= months; x++){
                 due = due.AddMonths(1);
                 double amount = _onlinePaymentService.Interest(value, x);
                 amount = _onlinePaymentService.PaymentFee(amount);
                 contract.AddInstallment(due, amount);
             }
         }
    }
}