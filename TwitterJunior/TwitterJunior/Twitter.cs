using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace TwitterJunior
{
    public class Twitter
    {
        public Twitter()
        {
            this.UserFollowing = new Dictionary<int, List<int>>();
            this.TweetsOwners = new Dictionary<int, int>();
            this.Tweets = new List<int>();
        }


        public Dictionary<int, List<int>> UserFollowing { get; set; }

        public Dictionary<int, int> TweetsOwners { get; set; }

        public List<int> Tweets { get; set; }


        public void PostTweet(int userId, int tweetId)
        {
            TweetsOwners[tweetId] = userId;
            Tweets.Add(tweetId);

        }

        public IList<int> GetNewsFeed(int userId)
        {
            List<int> personalFeed = new List<int>();

            if (!UserFollowing.ContainsKey(userId))
            {
                UserFollowing[userId] = new List<int>();
            }

            for (int i = Tweets.Count - 1; i >= 0; i--)
            {
                if (UserFollowing[userId].Contains(TweetsOwners[Tweets[i]]) || (TweetsOwners[Tweets[i]] == userId))
                {
                    personalFeed.Add(Tweets[i]);
                }
            }

            return personalFeed.Take(10).ToList();

        }

        public void Follow(int followerId, int followeeId)
        {
            // If follower isn't already following followee then follower's id gets added to followee's list
            if (!UserFollowing.ContainsKey(followerId))
            {
                UserFollowing[followerId] = new List<int>();
            }

            if (!UserFollowing[followerId].Contains(followeeId))
            {
                UserFollowing[followerId].Add(followeeId);
            }
        }

        public void Unfollow(int followerId, int followeeId)
        {
            // If follower is following followee then follower's id gets removed from followee's list
            if (!UserFollowing.ContainsKey(followerId))
            {
                UserFollowing[followerId] = new List<int>();
            }

            if (UserFollowing[followerId].Contains(followeeId))
            {
                UserFollowing[followerId].Remove(followeeId);
            }

        }
    }
}
