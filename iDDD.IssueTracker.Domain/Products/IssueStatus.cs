﻿using Headspring;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class IssueStatus : Enumeration<IssueStatus>
    {
        private IssueStatus(int value, string displayName) : base(value, displayName)
        {
        }

        public static readonly IssueStatus Open = new IssueStatus(0, "Open");
    }
}