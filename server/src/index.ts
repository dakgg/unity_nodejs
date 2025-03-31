import { ApolloServer, gql } from 'apollo-server';

const typeDefs = gql`
  type Player {
    id: ID!
    name: String!
    score: Int!
  }

  type Query {
    player(id: ID!): Player
  }

  type Mutation {
    createPlayer(name: String!, score: Int!): Player
  }
`;

interface Player {
    id: string;
    name: string;
    score: number;
}

const players: Player[] = [];

const resolvers = {
    Query: {
        player: (_: any, { id }: { id: string }) => players.find(p => p.id === id),
    },
    Mutation: {
        createPlayer: (_: any, { name, score }: { name: string; score: number }) => {
            const newPlayer = { id: `${players.length + 1}`, name, score };
            players.push(newPlayer);
            return newPlayer;
        },
    },
};

const server = new ApolloServer({ typeDefs, resolvers });

server.listen().then(({ url }) => {
    console.log(`Server ready at ${url}`);
});