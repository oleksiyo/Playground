using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Xunit;

namespace CQRSDemoAppTests
{
    public class AutoMoqDataAttribute :AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(new Fixture()
                .Customize(new AutoMoqCustomization()))
        {}
    }
}