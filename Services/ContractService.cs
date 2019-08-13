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
             double basicQuota = contract.TotalValue / months;

             for(int x = 1; x <= months; x++){
                 DateTime due = contract.Date.AddMonths(x);
                 double updateQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, x);
                 double fullQuota = updateQuota + _onlinePaymentService.PaymentFee(updateQuota);
                 contract.AddInstallment(new Installment(due, fullQuota));
             }
         }
    }
}