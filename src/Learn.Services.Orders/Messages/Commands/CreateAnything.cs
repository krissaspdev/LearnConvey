using Convey.CQRS.Commands;
using Newtonsoft.Json;

namespace Learn.Services.Orders.Messages.Commands
{
    public class CreateAnything: ICommand
    {
        public int Typ { get; }

        [JsonConstructor]
        public CreateAnything(int typ)
        {
            Typ = typ;
        }
    }
}