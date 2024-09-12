export interface Post {
    id: number;
    title: string;
    description: string;
    payment: number;
    location: string;
    date: Date;
    creatorClerkId: string;
    creatorName: string;
    fulfillerClerkId: string;
    isFulfilled: boolean;
    isAborted: boolean;
    imageUrl?: string;  
    reviewOnCreator?:Review;
    reviewOnFulfiller?:Review;
    

  }

  export interface Review {
    id: number;
    creatorClerkId: string;
    fulfillerClerkId: string;
    rating: number;
    body:string;
    

  }

  export interface MyUser {
    id:number;
    clerkId:string;
    name: string;
    imageUrl: string;
    activePost: Post;
    postHistory: Post[];
    acceptedJobs: Post[];

  }