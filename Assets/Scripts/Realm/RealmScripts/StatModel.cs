
using System;
using MongoDB.Bson;
using Realms;
// TODO: Realm-ify Player model
public class Stat {
 public ObjectId Id;
 public int score = 0;
 public int enemiesDefeated = 0;
 public int tokensCollected = 0;
 public Player statOwner;
}
