﻿using System;
using NExtra.Date;
using NUnit.Framework;

namespace NExtra.Tests.Date
{
    [TestFixture]
    public class Iso8601WeekResolverBehavior
    {
        private IWeekResolver _resolver;


        [SetUp]
        public void SetUp()
        {
            _resolver = new Iso8601WeekResolver();
        }


        [Test]
        public void GetFirstDateOfWeek_ShouldHandleMinValue()
        {
            Assert.That(_resolver.GetFirstDateOfWeek(DateTime.MinValue), Is.EqualTo(DateTime.MinValue));
        }

        [Test]
        public void GetFirstDateOfWeek_041231ShouldReturn041227()
        {
            Assert.That(_resolver.GetFirstDateOfWeek(new DateTime(2004, 12, 31)), Is.EqualTo(new DateTime(2004, 12, 27)));
        }

        [Test]
        public void GetFirstDateOfWeek_050101ShouldReturn041227()
        {
            Assert.That(_resolver.GetFirstDateOfWeek(new DateTime(2005, 01, 01)), Is.EqualTo(new DateTime(2004, 12, 27)));
        }

        [Test]
        public void GetFirstDateOfWeek_051231ShouldReturn051226()
        {
            Assert.That(_resolver.GetFirstDateOfWeek(new DateTime(2005, 12, 31)), Is.EqualTo(new DateTime(2005, 12, 26)));
        }

        [Test]
        public void GetFirstDateOfWeek_060101ShouldReturn051226()
        {
            Assert.That(_resolver.GetFirstDateOfWeek(new DateTime(2006, 01, 01)), Is.EqualTo(new DateTime(2005, 12, 26)));
        }

        [Test]
        public void GetFirstDateOfWeek_081231ShouldReturn081229()
        {
            Assert.That(_resolver.GetFirstDateOfWeek(new DateTime(2008, 12, 31)), Is.EqualTo(new DateTime(2008, 12, 29)));
        }

        [Test]
        public void GetFirstDateOfWeek_090101ShouldReturn081229()
        {
            Assert.That(_resolver.GetFirstDateOfWeek(new DateTime(2009, 01, 01)), Is.EqualTo(new DateTime(2008, 12, 29)));
        }


        [Test]
        public void GetLastDateOfWeek_ShouldHandleMaxValue()
        {
            Assert.That(_resolver.GetLastDateOfWeek(DateTime.MaxValue), Is.EqualTo(DateTime.MaxValue));
        }

        [Test]
        public void GetLastDateOfWeek_041231ShouldReturn050102()
        {
            Assert.That(_resolver.GetLastDateOfWeek(new DateTime(2004, 12, 31)), Is.EqualTo(new DateTime(2005, 01, 02)));
        }

        [Test]
        public void GetLastDateOfWeek_050101ShouldReturn050102()
        {
            Assert.That(_resolver.GetLastDateOfWeek(new DateTime(2005, 01, 01)), Is.EqualTo(new DateTime(2005, 01, 02)));
        }

        [Test]
        public void GetLastDateOfWeek_051231ShouldReturn060101()
        {
            Assert.That(_resolver.GetLastDateOfWeek(new DateTime(2005, 12, 31)), Is.EqualTo(new DateTime(2006, 01, 01)));
        }

        [Test]
        public void GetLastDateOfWeek_060101ShouldReturn060101()
        {
            Assert.That(_resolver.GetLastDateOfWeek(new DateTime(2006, 01, 01)), Is.EqualTo(new DateTime(2006, 01, 01)));
        }

        [Test]
        public void GetLastDateOfWeek_081231ShouldReturn090104()
        {
            Assert.That(_resolver.GetLastDateOfWeek(new DateTime(2008, 12, 31)), Is.EqualTo(new DateTime(2009, 01, 04)));
        }

        [Test]
        public void GetLastDateOfWeek_090101ShouldReturn090104()
        {
            Assert.That(_resolver.GetLastDateOfWeek(new DateTime(2009, 01, 01)), Is.EqualTo(new DateTime(2009, 01, 04)));
        }
        [Test]
        public void GetWeekNumber_ShouldHandleMinValue()
        {
            var week = _resolver.GetWeekNumber(DateTime.MinValue);
            Assert.That(week, Is.GreaterThan(0));
            Assert.That(week, Is.LessThanOrEqualTo(53));
        }

        [Test]
        public void GetWeekNumber_ShouldHandleMaxValue()
        {
            var week = _resolver.GetWeekNumber(DateTime.MaxValue);
            Assert.That(week, Is.GreaterThan(0));
            Assert.That(week, Is.LessThanOrEqualTo(53));
        }

        [Test]
        public void GetWeekNumber_041231ShouldReturn53()
        {
            Assert.That(_resolver.GetWeekNumber(new DateTime(2004, 12, 31)), Is.EqualTo(53));
        }

        [Test]
        public void GetWeekNumber_050101ShouldReturn53()
        {
            Assert.That(_resolver.GetWeekNumber(new DateTime(2005, 01, 01)), Is.EqualTo(53));
        }

        [Test]
        public void GetWeekNumber_061231ShouldReturn52()
        {
            Assert.That(_resolver.GetWeekNumber(new DateTime(2006, 12, 31)), Is.EqualTo(52));
        }

        [Test]
        public void GetWeekNumber_070101ShouldReturn1()
        {
            Assert.That(_resolver.GetWeekNumber(new DateTime(2007, 01, 01)), Is.EqualTo(1));
        }

        [Test]
        public void GetWeekNumber_081231ShouldReturn1()
        {
            Assert.That(_resolver.GetWeekNumber(new DateTime(2008, 12, 31)), Is.EqualTo(1));
        }

        [Test]
        public void GetWeekNumber_090101ShouldReturn1()
        {
            Assert.That(_resolver.GetWeekNumber(new DateTime(2009, 01, 01)), Is.EqualTo(1));
        }
    }
}
