using System;

namespace Domain.Services.Promotions;

public interface IOrderPoints {

    String Id { get; }

    String Name  {get;}

    Int32 Points { get; }
}