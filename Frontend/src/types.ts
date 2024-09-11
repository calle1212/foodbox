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

  export interface Review {
    id: number;
    rating: number;
  }

  export interface MyUser {
    id:number;
    clerkId:string;
    name: string;
    imageUrl: string;
    reviews: Review[];
    activePost: Post;
    postHistory: Post[];
  }