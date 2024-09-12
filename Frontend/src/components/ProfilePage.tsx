import { SignIn, SignInButton, UserButton, useUser } from "@clerk/clerk-react";
import { useQuery } from "@tanstack/react-query";
import { useMatch, Link } from '@tanstack/react-router';
import { MyUser } from "../types";
import ReviewComponent from "./ReviewComponent";
import CreatedDealHistoryComponent from "./CreatedDealHistoryComponent";


export default function ProfilePage() {
    const { search } = useMatch("/profile");
    let qid = search.id;
    const { user } = useUser();
    
    if (!qid) qid = user?.id;
    const { isPending, error, data, isFetching } = useQuery<MyUser>({
        queryKey: ["ProfileData", qid],
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
                {data.activePost && <Link className="btn" to="/deal" search={{ id: { data }.data.clerkId, }} >Check out {data.name}' active deal</Link>}



                <details>
                <summary>Created Deals History</summary>

                <div className="overflow-x-auto">
                    <table className="table table-xs">
                        <thead>
                            <tr>
                                <th></th>
                                <th>Name</th>
                                <th>Job</th>
                                <th>company</th>
                                <th>location</th>
                                <th>Last Login</th>
                                <th>Favorite Color</th>
                            </tr>
                        </thead>
                        <tbody>
                            {data.postHistory.map(post => <CreatedDealHistoryComponent {...post} key={post.id} />)}
                        </tbody>
                    </table>
                </div>
                </details>


                <details>
                    <summary>Fulfilled Deals History</summary> 


                <div className="overflow-x-auto">
                    <table className="table table-xs">
                        <thead>
                            <tr>
                                <th></th>
                                <th>Name</th>
                                <th>Job</th>
                                <th>company</th>
                                <th>location</th>
                                <th>Last Login</th>
                                <th>Favorite Color</th>
                            </tr>
                        </thead>
                        <tbody>
                            {data.postHistory.map(post => <CreatedDealHistoryComponent {...post} key={post.id} />)}
                        </tbody>
                    </table>
                </div>
                </details>


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