import { useUser } from "@clerk/clerk-react";
import { useQueryClient, useMutation } from "@tanstack/react-query";
import { Post } from "../types";
import { Link } from '@tanstack/react-router';


export default function CreatedDealHistoryComponent(post : Post){
  
    console.log("fulfillers id:"+ post.fulfillerClerkId)
    console.log("creators id:"+ post.creatorClerkId)

    //const user= useUser();

    const queryClient = useQueryClient();

    const completeJobQuery  = useMutation({
        mutationFn: () => {
            return fetch(`http://localhost:5063/api/Posts/FulfillJob?creatorClerkId=${post.creatorClerkId}&postId=${post.id}`, {
                method: "PATCH",
            })
        },
        onSuccess: () => queryClient.invalidateQueries({ queryKey: ["ProfileData", post.creatorClerkId] }) 
    });

    function completeJob(){
        console.log("hello from accept job")
        completeJobQuery.mutate();
    }

    return (
    <tr>
        <td>{post.title}</td>
        <td>{post.description}</td>
        <td>{post.date}</td>
        {post.fulfillerClerkId != "" && <td> <Link to="/profile" search={{id: post.fulfillerClerkId}} className="btn"> Fulfiller profile</Link></td> }
        {post.fulfillerClerkId == "" && <td> No fulfiller yet! </td> }

        <td>{post.reviewOnCreator && post.reviewOnCreator.rating}</td>
        <td>{
          post.isFulfilled ? <p className="text-green-600">Completed</p> 
        : post.isAborted ? <p className="text-red-600">Aborted</p>
        : post.fulfillerClerkId != "" ? <button className="btn" onClick={completeJob}>Mark as completed</button>
        : <button className="btn">Abort deal</button>}</td>

    </tr>
    )
}
