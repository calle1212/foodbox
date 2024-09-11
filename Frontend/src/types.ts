export interface Post {
    id: number;
    title: string;
    description: string;
    payment: number;
    location: string;
    date: Date;
    creatorClerkId: string;
    fulfillerClerkId?: string;
    imageUrl?: string;         
  }