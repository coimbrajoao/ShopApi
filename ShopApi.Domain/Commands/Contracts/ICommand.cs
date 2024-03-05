using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;

namespace ShopApi.Domain.Commands.Contracts
{
    public abstract class  ICommand : Notifiable<Notification>
    {
      public abstract void Validate();    
    }
}