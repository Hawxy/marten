using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Marten.Events.Aggregation;
using Marten.Events.Projections;
using Marten.Storage;
using Marten.Testing.Events.Aggregation;
using Marten.Testing.Harness;
using Shouldly;
using Xunit;

#if NET
namespace Marten.Testing.Events.Bugs
{
    public class inline_projection_multiple_delete_should_not_throw: BugIntegrationContext
    {

        [Fact]
        public async Task inline_projection_multiple_delete_operations_should_not_throw()
        {
            StoreOptions(x =>
            {
                x.Policies.AllDocumentsAreMultiTenanted();
                x.Events.TenancyStyle = TenancyStyle.Conjoined;
                x.Projections.Add(new ContactProjection());
                //Create exactly 17 projections as Array.Sort changes internally from a quick sort to an introspective sort
                x.Projections.Add(new SomeOtherTypeProjection());
                x.Projections.Add(new SomeOtherTypeProjection2());
                x.Projections.Add(new SomeOtherTypeProjection3());
                x.Projections.Add(new SomeOtherTypeProjection4());
                x.Projections.Add(new SomeOtherTypeProjection5());
                x.Projections.Add(new SomeOtherTypeProjection6());
                x.Projections.Add(new SomeOtherTypeProjection7());
                x.Projections.Add(new SomeOtherTypeProjection8());
                x.Projections.Add(new SomeOtherTypeProjection9());
                x.Projections.Add(new SomeOtherTypeProjection10());
                x.Projections.Add(new SomeOtherTypeProjection11());
                x.Projections.Add(new SomeOtherTypeProjection12());
                x.Projections.Add(new SomeOtherTypeProjection13());
                x.Projections.Add(new SomeOtherTypeProjection14());
                x.Projections.Add(new SomeOtherTypeProjection15());
                x.Projections.Add(new SomeOtherTypeProjection16());
                x.Projections.Add(new SomeOtherTypeProjection17());
                x.Projections.Add(new SomeOtherTypeProjection18());
                x.Projections.Add(new SomeOtherTypeProjection19());
                x.Projections.Add(new SomeOtherTypeProjection20());

            }, true);


            await using var session = theStore.LightweightSession("x");

            var id = Guid.NewGuid();
            session.Events.StartStream(id, new ContactCreated(id, "x"));

            await session.SaveChangesAsync();

        }

        public class ContactProjection: AggregateProjection<Contact>
        {
            public ContactProjection()
            {
                ProjectionName = nameof(Contact);
                Lifecycle = ProjectionLifecycle.Inline;

                CreateEvent<ContactCreated>(Contact.Create);
            }
        }

       
    }

    public interface ICreateEvent { Guid Id { get; init; } }
    public record ContactCreated(Guid Id, string Name): ICreateEvent;
    public record Contact(Guid Id, string Name)
    {
        public static Contact Create(ContactCreated e) => new(e.Id, e.Name);
    }

    public record SomeOtherType(Guid Id);
    public class SomeOtherTypeProjection: AggregateProjection<SomeOtherType>
    {
        public SomeOtherTypeProjection()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }

    public record SomeOtherType2(Guid Id);
    public class SomeOtherTypeProjection2: AggregateProjection<SomeOtherType2>
    {
        public SomeOtherTypeProjection2()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType3(Guid Id);
    public class SomeOtherTypeProjection3: AggregateProjection<SomeOtherType3>
    {
        public SomeOtherTypeProjection3()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType4(Guid Id);
    public class SomeOtherTypeProjection4: AggregateProjection<SomeOtherType4>
    {
        public SomeOtherTypeProjection4()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType5(Guid Id);
    public class SomeOtherTypeProjection5: AggregateProjection<SomeOtherType5>
    {
        public SomeOtherTypeProjection5()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType6(Guid Id);
    public class SomeOtherTypeProjection6: AggregateProjection<SomeOtherType6>
    {
        public SomeOtherTypeProjection6()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType7(Guid Id);
    public class SomeOtherTypeProjection7: AggregateProjection<SomeOtherType7>
    {
        public SomeOtherTypeProjection7()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType8(Guid Id);
    public class SomeOtherTypeProjection8: AggregateProjection<SomeOtherType8>
    {
        public SomeOtherTypeProjection8()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType9(Guid Id);
    public class SomeOtherTypeProjection9: AggregateProjection<SomeOtherType9>
    {
        public SomeOtherTypeProjection9()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType10(Guid Id);
    public class SomeOtherTypeProjection10: AggregateProjection<SomeOtherType10>
    {
        public SomeOtherTypeProjection10()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType11(Guid Id);
    public class SomeOtherTypeProjection11: AggregateProjection<SomeOtherType11>
    {
        public SomeOtherTypeProjection11()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType12(Guid Id);
    public class SomeOtherTypeProjection12: AggregateProjection<SomeOtherType12>
    {
        public SomeOtherTypeProjection12()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType13(Guid Id);
    public class SomeOtherTypeProjection13: AggregateProjection<SomeOtherType13>
    {
        public SomeOtherTypeProjection13()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType14(Guid Id);
    public class SomeOtherTypeProjection14: AggregateProjection<SomeOtherType14>
    {
        public SomeOtherTypeProjection14()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType15(Guid Id);
    public class SomeOtherTypeProjection15: AggregateProjection<SomeOtherType15>
    {
        public SomeOtherTypeProjection15()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType16(Guid Id);
    public class SomeOtherTypeProjection16: AggregateProjection<SomeOtherType16>
    {
        public SomeOtherTypeProjection16()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType17(Guid Id);
    public class SomeOtherTypeProjection17: AggregateProjection<SomeOtherType17>
    {
        public SomeOtherTypeProjection17()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType18(Guid Id);
    public class SomeOtherTypeProjection18: AggregateProjection<SomeOtherType18>
    {
        public SomeOtherTypeProjection18()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType19(Guid Id);
    public class SomeOtherTypeProjection19: AggregateProjection<SomeOtherType19>
    {
        public SomeOtherTypeProjection19()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
    public record SomeOtherType20(Guid Id);
    public class SomeOtherTypeProjection20: AggregateProjection<SomeOtherType20>
    {
        public SomeOtherTypeProjection20()
        {
            Lifecycle = ProjectionLifecycle.Inline;
            CreateEvent<ICreateEvent>((_) => null);
        }
    }
}
#endif
