import { UserButton, useUser } from "@clerk/clerk-react";
import { useQuery } from "@tanstack/react-query";
import { useMatch, Link } from '@tanstack/react-router';
import { Post, MyUser } from "../types";
import ReviewComponent from "./ReviewComponent";
import DealHistoryComponent from "./DealHistoryComponent";


export default function ProfilePage() {
    const { search } = useMatch("/profile");
    const qid = search.id;
    const { user } = useUser();


    const { isPending, error, data, isFetching } = useQuery<MyUser>({
        queryKey: ["ProfileData"],
        queryFn: async () => {
            const response = await fetch(
                `http://localhost:5063/api/Users?id=${qid}`,
            )
            return await response.json()
        },
    })

    if (isPending) return 'Loading...';
    if (error) return 'An error has occurred: ' + error.message
    if (isFetching) return "is fetching...";
    return (
        <div className="flex flex-col items-center gap-4">
            <UserButton />
            <h1 className="text-2xl">{data.name} </h1>
            
            <h2>Active Deal</h2>
            {data.activePost && <Link className="btn" to="/deal" search={{ id: {data}.data.activePost.id,}} >Check out {data.name}' active deal</Link> }
        
            <h2>Reviews</h2>
            {data.reviews.map(review => <ReviewComponent {...review} key={review.id}/>)}

            <h2>Deal history</h2>
            {data.postHistory.map(post => <DealHistoryComponent {...post} key={post.id}/>)}


            {user?.id == qid && <button className="btn">Update Information</button>}
        </div>
    )
}