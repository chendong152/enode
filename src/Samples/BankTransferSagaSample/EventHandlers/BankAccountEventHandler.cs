﻿using System;
using BankTransferSagaSample.Commands;
using BankTransferSagaSample.Events;
using ENode.Commanding;
using ENode.Eventing;

namespace BankTransferSagaSample.EventHandlers
{
    public class BankAccountEventHandler :
        IEventHandler<AccountOpened>,
        IEventHandler<Deposited>,
        IEventHandler<TransferedOut>,
        IEventHandler<TransferedIn>
    {
        private ICommandService _commandService;

        public BankAccountEventHandler(ICommandService commandService)
        {
            _commandService = commandService;
        }

        void IEventHandler<AccountOpened>.Handle(AccountOpened evnt)
        {
            Console.WriteLine(string.Format("创建账户{0}", evnt.AccountNumber));
        }
        void IEventHandler<Deposited>.Handle(Deposited evnt)
        {
            Console.WriteLine(evnt.Description);
        }
        void IEventHandler<TransferedOut>.Handle(TransferedOut evnt)
        {
            Console.WriteLine(evnt.Description);
            _commandService.Send(new HandleTransferedOut(evnt));
        }
        void IEventHandler<TransferedIn>.Handle(TransferedIn evnt)
        {
            Console.WriteLine(evnt.Description);
            _commandService.Send(new HandleTransferedIn(evnt));
        }
    }
}
