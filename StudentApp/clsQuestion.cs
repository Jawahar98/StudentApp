using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    public class ClsQuestion
    {
        public class AssessmentType
        {
            public string _id { get; set; }
            public string name { get; set; }
            public string _courseGroup { get; set; }
        }

        public class ExamType
        {
            public string _id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }

        public class Settings
        {
            public string type { get; set; }
            public int totalMarks { get; set; }
            public int totalDuration { get; set; }
            public int totalItems { get; set; }
            public string showFeedBackAt { get; set; }
            public string shuffleSections { get; set; }
            public string answeringSequenceOfSection { get; set; }
            public bool answerAllItemsToEndExam { get; set; }
            public int minimumExamDuration { get; set; }
            public int maximumLateEntryDuration { get; set; }
            public bool isAllowedToNavigateUpcomingItems { get; set; }
        }

        public class Settings2
        {
            public string shuffleItems { get; set; }
            public string shuffleItemsWithinGroup { get; set; }
            public string shuffleChoicesWithinItems { get; set; }
            public string answeringSequenceOfItem { get; set; }
        }

        public class Type
        {
            public string _id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }

        public class Answer
        {
            public string _id { get; set; }
            public string text { get; set; }
            public string label { get; set; }
            public string displayLabel { get; set; }
        }

        public class Attachment
        {
            public string type { get; set; }
            public string path { get; set; }
        }

        public class Attachment2
        {
            public string type { get; set; }
            public string path { get; set; }
        }
        public class Attachment5
        {
            public string type { get; set; }
            public string path { get; set; }
            public string bundlePath { get; set; }
        }
        public class LeadIn
        {
            public string text { get; set; }
            public List<Attachment2> attachments { get; set; }
        }

        public class Question
        {
            public double marks { get; set; }
            public Answer answer { get; set; }
            public bool isbookmark { get; set; }
            public bool isattended { get; set; }
            public string text { get; set; }
            public List<Attachment> attachments { get; set; }
            public string theme { get; set; }
            public LeadIn leadIn { get; set; }
            public List<Attachment4> importAttachments { get; set; }
        }

        public class Attachment3
        {
            public string type { get; set; }
            public string path { get; set; }
        }
        public class Attachment4
        {
            public string type { get; set; }
            public string path { get; set; }
        }
        public class Answer2
        {
            public string _id { get; set; }
            public string text { get; set; }
            public string label { get; set; }
            public string displayLabel { get; set; }
        }

        public class Option
        {
            public string _id { get; set; }
            public string text { get; set; }
            public string label { get; set; }
        }

        public class Question2
        {
            public string _id { get; set; }
            public double marks { get; set; }
            public bool isbookmark { get; set; }
            public bool isattended { get; set; }
            public string text { get; set; }
            public List<Attachment3> attachments { get; set; }
            public Answer2 answer { get; set; }
            public List<Option> options { get; set; }
        }

        public class Stem
        {
            public Question question { get; set; }
            public List<Question2> questions { get; set; }
        }

        public class Feedback
        {
            public string correctAnswers { get; set; }
            public string wrongAnswers { get; set; }
        }

        public class Option2
        {
            public string _id { get; set; }
            public string text { get; set; }
            public string label { get; set; }
            public List<Attachment5> attachments { get; set; }
        }

        public class Item
        {
            public string _id { get; set; }
            public Type type { get; set; }
            public int duration { get; set; }
            public int timeTaken { get; set; }
            public Stem stem { get; set; }
            public Feedback feedback { get; set; }
            public List<Option2> options { get; set; }
        }

        public class Section
        {
            public string _id { get; set; }
            public int duration { get; set; }
            public int marks { get; set; }
            public Settings2 settings { get; set; }
            public string itemTypeCode { get; set; }
            public List<Item> items { get; set; }
        }

        public class ItemType
        {
            public string _id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }

        public class Option3
        {
            public string name { get; set; }
            public string label { get; set; }
        }

        public class Values
        {
            public int min { get; set; }
            public int max { get; set; }
            public int interval { get; set; }
        }

        public class SurveyItem
        {
            public string _id { get; set; }
            public ItemType itemType { get; set; }
            public string content { get; set; }
            public string answer { get; set; }
            public List<Option3> options { get; set; }
            public Values values { get; set; }
        }

        public class Survey
        {
            public string name { get; set; }
            public List<SurveyItem> items { get; set; }
        }
        public class RootFetchDB
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            [JsonConverter(typeof(ObjectIdConverter))]
            public ObjectId _id { get; set; }
            public string Sessionid { get; set; }
            public string Assessmentid { get; set; }
            public string CourseID { get; set; }
            public string Date { get; set; }
            public string name { get; set; }
            public string MACAddress { get; set; }
            public string StudentName { get; set; }
            public string AcademicNo { get; set; }
            public string TestCenter { get; set; }
            public AssessmentType assessmentType { get; set; }
            public ExamType examType { get; set; }
            public Settings settings { get; set; }
            public List<Section> sections { get; set; }
            public List<Survey> surveys { get; set; }
        }
        public class Root
        {
            [JsonProperty(PropertyName = "_id")]
            public string Assessmentid { get; set; }
            public string Sessionid { get; set; }
            public string CourseID { get; set; }
            public string Date { get; set; }
            public string name { get; set; }
            public string MACAddress { get; set; }
            public string StudentName { get; set; }
            public string AcademicNo { get; set; }
            public string TestCenter { get; set; }
            public AssessmentType assessmentType { get; set; }
            public ExamType examType { get; set; }
            public Settings settings { get; set; }
            public List<Section> sections { get; set; }
            public List<Survey> surveys { get; set; }
        }

        public class Message
        {
            public string message { get; set; }
            public Root data { get; set; }
        }
        public class SessinoMaintenance
        {

            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            [JsonConverter(typeof(ObjectIdConverter))]
            public ObjectId _id { get; set; }
            public string SessionID { get; set; }
            public string Date { get; set; }
            public string TestCenter { get; set; }
            public string CourseID { get; set; }
            public string AcademicNo { get; set; }
            public bool IsAuthenticated { get; set; }
            public int LastSectionIndex { get; set; }
            public int LastItemIndex { get; set; }
            public int CurrentQuestionNo { get; set; }
            public int TotalTimeLeft { get; set; }
            public int SectionTimeLeft { get; set; }
            public int ItemTimeLeft { get; set; }
            public string UpdatedTime { get; set; }
        }
    }
    public class ObjectIdConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ObjectId).IsAssignableFrom(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            var value = (string)reader.Value;
            return string.IsNullOrEmpty(value) ? ObjectId.Empty : new ObjectId(value);
        }
    }

}
