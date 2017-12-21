using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_ClassLib
{
    public class Class1
    {
        // We maintain a dictionary of collections keyed by a session id.
        static Dictionary<String, IMongoCollection<BsonDocument>> collectionDictionary = new Dictionary<String, IMongoCollection<BsonDocument>>();

        /**
         * @brief Open a new connection to the database.
         * @param [in] connectionString
         * @param[in] databaseName
         * @param[in] collectionName
         */
        public static void NewSession(String connectionString, String sessionName, String databaseName, String collectionName)
        {
            var client = new MongoClient(connectionString);
            var database   = client.GetDatabase(databaseName);
            var collection = database.GetCollection<BsonDocument>(collectionName);
            collectionDictionary.Add(sessionName, collection);  // Add the collection entry into the dictionary.
        } // NewSession


        /**
         * @brief Insert a new document into the DB.
         * @param [in] sessionName The session into which we wish to insert the document.
         * @param [in] doc The document to insert.
         */
        public static void Insert(String sessionName, String doc)
        {
            var collection = collectionDictionary[sessionName];
            var document   = BsonSerializer.Deserialize<BsonDocument>(doc);
            collection.InsertOne(document);
        } // Insert


        /**
         * @brief Delete a document from the collection
         * @param [in] sessionName The session from which we wish to delete the document.
         * @param [in] doc The key to the doc to delete.
         */
        public static void Delete(String sessionName, String doc)
        {
            var bsonDoc    = BsonSerializer.Deserialize<BsonDocument>(doc);
            var collection = collectionDictionary[sessionName];
            collection.DeleteOne(bsonDoc);
        } // Delete


        /**
         * @brief Find a document
         */
        public static String Find(String sessionName, String doc)
        {
            var bsonDoc    = BsonSerializer.Deserialize<BsonDocument>(doc);
            var collection = collectionDictionary[sessionName];
            return collection.FindSync(bsonDoc).ToList().ToJson();
        } // Find


        /**
         * @brief End the session.
         * @param [in] sessionName Remove the named session.
         */
        public static void EndSession(String sessionName)
        {
            collectionDictionary.Remove(sessionName);  // Remove the collection entry from the dictionary.
        } // EndSession
    }
}
