import { SignIn, SignInButton, UserButton, useUser } from "@clerk/clerk-react";
import { useQuery } from "@tanstack/react-query";
import { useMatch, Link } from '@tanstack/react-router';
import { Post, MyUser } from "../types";
import ReviewComponent from "./ReviewComponent";
import CreatedDealHistoryComponent from "./CreatedDealHistoryComponent";


export default function ProfilePage() {
    const { search } = useMatch("/profile");
    let qid = search.id;
    const { user } = useUser();
    if (!qid) qid = user?.id;

    const { isPending, error, data, isFetching } = useQuery<MyUser>({
        queryKey: ["ProfileData"],
        queryFn: async () => {
            const response = await fetch(
                `http://localhost:5063/api/Users?id=${qid}`,
            )
            return await response.json()
        },
    })
    if (user) {
        if (isPending) return 'Loading...';
        if (error) return 'An error has occurred: ' + error.message
        if (isFetching) return "is fetching...";
        return (
            <div className="flex flex-col items-center gap-4">

                <h1 className="text-2xl font-semibold">{data.name} </h1>
                <figure className=" ">
                    <img
                        className="w-52 h-52"
                        src={data.imageUrl || "http://www.clipartbest.com/cliparts/M9i/4d7/M9i4d79cE.png"}
                        alt="Food image" />
                </figure>
                <h2>Active Deal</h2>
                {data.activePost && <Link className="btn" to="/deal" search={{ id: { data }.data.activePost.id, }} >Check out {data.name}' active deal</Link>}

               
               

                <h2>Deal history</h2>
                {data.postHistory.map(post => <CreatedDealHistoryComponent {...post} key={post.id} />)}


                {user?.id == qid && <button className="btn">Update Information</button>}
            </div>
        )
    }
    else {
        return (
            <div className="flex flex-col items-center p-16 gap-5">
                <h1 className="text-3xl">Log in or Register an account</h1>
                <SignIn />
            </div>
        )
    }
}