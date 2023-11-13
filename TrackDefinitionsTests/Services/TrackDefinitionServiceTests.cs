using NUnit.Framework;
using TrackDefinitionsAPI.Models;
using TrackDefinitionsAPI.Services;
using Assert = NUnit.Framework.Assert;

namespace TrackDefinitionsTests.Services
{
    public class TrackDefinitionServiceTests
    {
        private readonly ITrackDefinitionService _trackDefinitionService;

        public TrackDefinitionServiceTests()
        {
            _trackDefinitionService = new TrackDefinitionService();
        }

        [Fact]
        public void ProcessTrack_TrackDefinitionService_ShouldReturnCorrectResultsFor_EDM()
        {
            // Arrange
            var track = new TrackDefinitionModel
            {
                Title = "Test Track",
                Artist = "Test Artist",
                StreamCount = 1000,
                Tags = new List<string> { "techno" },
                Advance = 500
            };

            // Act
            var results = _trackDefinitionService.ProcessTrack(track);

            // Assert
            Assert.AreEqual("EDM", results[0].Department);
        }

        [Fact]
        public void ProcessTrack_TrackDefinitionService_ShouldReturnCorrectResultsFor_Trance()
        {
            // Arrange
            var track = new TrackDefinitionModel
            {
                Title = "Test Track",
                Artist = "Test Artist",
                StreamCount = 1000,
                Tags = new List<string> { "trance" },
                Advance = 500
            };

            // Act
            var results = _trackDefinitionService.ProcessTrack(track);

            // Assert
            Assert.AreEqual("Trance", results[0].Department);
        }

        [Fact]
        public void ProcessTrack_TrackDefinitionService_ShouldReturnCorrectResultsFor_Acid()
        {
            // Arrange
            var track = new TrackDefinitionModel
            {
                Title = "Test Track",
                Artist = "Test Artist",
                StreamCount = 1000,
                Tags = new List<string> { "acid" },
                Advance = 500
            };

            // Act
            var results = _trackDefinitionService.ProcessTrack(track);

            // Assert
            Assert.AreEqual("Acid", results[0].Department);
        }

        [Fact]
        public void ProcessTrack_TrackDefinitionService_ShouldReturnCorrectResultsFor_Default()
        {
            // Arrange
            var track = new TrackDefinitionModel
            {
                Title = "Test Track",
                Artist = "Test Artist",
                StreamCount = 1000,
                Tags = new List<string> { "123" },
                Advance = 500
            };

            // Act
            var results = _trackDefinitionService.ProcessTrack(track);

            // Assert
            Assert.AreEqual("Default", results[0].Department);
        }

        [Fact]
        public void ProcessTrack_TrackDefinitionService_ShouldRequireApprovalWhenPredictedProfitLessThanThresholdFor_EDM()
        {
            // Arrange
            var track = new TrackDefinitionModel
            {
                Title = "Test Track",
                Artist = "Test Artist",
                StreamCount = 200000,
                Tags = new List<string> { "techno" },
                Advance = 1900
            };

            // Act
            var results = _trackDefinitionService.ProcessTrack(track);

            // Assert
            Assert.IsTrue(results[0].ApprovalRequired); // (predictedProfit) 100 < 1000
        }

        [Fact]
        public void ProcessTrack_TrackDefinitionService_ShouldNotRequireApprovalWhenPredictedProfitLessThanThresholdFor_EDM()
        {
            // Arrange
            var track = new TrackDefinitionModel
            {
                Title = "Test Track",
                Artist = "Test Artist",
                StreamCount = 200000,
                Tags = new List<string> { "techno" },
                Advance = 50
            };

            // Act
            var results = _trackDefinitionService.ProcessTrack(track);

            // Assert
            Assert.IsFalse(results[0].ApprovalRequired); // (predictedProfit) 1550 < 1000
        }

        [Fact]
        public void ProcessTrack_TrackDefinitionService_ShouldRequireApprovalWhenPredictedProfitLessThanThresholdFor_Trance()
        {
            // Arrange
            var track = new TrackDefinitionModel
            {
                Title = "Test Track",
                Artist = "Test Artist",
                StreamCount = 200000,
                Tags = new List<string> { "trance" },
                Advance = 2500
            };

            // Act
            var results = _trackDefinitionService.ProcessTrack(track);

            // Assert
            Assert.IsTrue(results[0].ApprovalRequired); // (predictedProfit) 450 < 800
        }

        [Fact]
        public void ProcessTrack_TrackDefinitionService_ShouldNotRequireApprovalWhenPredictedProfitLessThanThresholdFor_Trance()
        {
            // Arrange
            var track = new TrackDefinitionModel
            {
                Title = "Test Track",
                Artist = "Test Artist",
                StreamCount = 200000,
                Tags = new List<string> { "trance" },
                Advance = 50
            };

            // Act
            var results = _trackDefinitionService.ProcessTrack(track);

            // Assert
            Assert.IsFalse(results[0].ApprovalRequired); // (predictedProfit) 2655 < 800
        }

        [Fact]
        public void ProcessTrack_TrackDefinitionService_ShouldRequireApprovalWhenPredictedProfitLessThanThresholdFor_Acid()
        {
            // Arrange
            var track = new TrackDefinitionModel
            {
                Title = "Test Track",
                Artist = "Test Artist",
                StreamCount = 200000,
                Tags = new List<string> { "acid" },
                Advance = 1200
            };

            // Act
            var results = _trackDefinitionService.ProcessTrack(track);

            // Assert
            Assert.IsTrue(results[0].ApprovalRequired); // (predictedProfit) 1040 < 1200
        }

        [Fact]
        public void ProcessTrack_TrackDefinitionService_ShouldNotRequireApprovalWhenPredictedProfitLessThanThresholdFor_Acid()
        {
            // Arrange
            var track = new TrackDefinitionModel
            {
                Title = "Test Track",
                Artist = "Test Artist",
                StreamCount = 200000,
                Tags = new List<string> { "acid" },
                Advance = 900
            };

            // Act
            var results = _trackDefinitionService.ProcessTrack(track);

            // Assert
            Assert.IsFalse(results[0].ApprovalRequired); // (predictedProfit) 1280 < 1200
        }

        [Fact]
        public void ProcessTrack_TrackDefinitionService_ShouldRequireApprovalWhenPredictedProfitLessThanThresholdFor_Default()
        {
            // Arrange
            var track = new TrackDefinitionModel
            {
                Title = "Test Track",
                Artist = "Test Artist",
                StreamCount = 200000,
                Tags = new List<string> { "123" },
                Advance = 900
            };

            // Act
            var results = _trackDefinitionService.ProcessTrack(track);

            // Assert
            Assert.IsTrue(results[0].ApprovalRequired); // (predictedProfit) 700 < 1100
        }

        [Fact]
        public void ProcessTrack_TrackDefinitionService_ShouldNotRequireApprovalWhenPredictedProfitLessThanThresholdFor_Default()
        {
            // Arrange
            var track = new TrackDefinitionModel
            {
                Title = "Test Track",
                Artist = "Test Artist",
                StreamCount = 200000,
                Tags = new List<string> { "123" },
                Advance = 500
            };

            // Act
            var results = _trackDefinitionService.ProcessTrack(track);

            // Assert
            Assert.IsFalse(results[0].ApprovalRequired); // (predictedProfit) 1200 < 1100
        }
    }
}