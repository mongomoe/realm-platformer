using System.Collections.Generic;
using MongoDB.Bson;
using Realms;

// TODO: Realm-ify Player model
public class Player {
 public string _id;
 public string name;
 public IList<Stat> stats;
}
