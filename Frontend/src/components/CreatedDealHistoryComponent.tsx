import { Post } from "../types";
import { Link } from '@tanstack/react-router';


export default function CreatedDealHistoryComponent(post : Post){
  
    console.log("fulfillers id:"+ post.fulfillerClerkId)
    console.log("creators id:"+ post.creatorClerkId)

    return (
    <tr>
        <td>{post.title}</td>
        <td>{post.description}</td>
        <td>{post.date}</td>
        {post.fulfillerClerkId != "" && <td> <Link to="/profile" search={{id: post.fulfillerClerkId}} className="btn"> Fulfiller profile</Link></td> }
        {post.fulfillerClerkId == "" && <td> No fulfiller yet! </td> }

        <td>{post.reviewOnCreator && post.reviewOnCreator.rating}</td>
        <td>{post.isFulfilled ? <p className="text-green-600">Completed</p> : <button className="btn">Mark as completed</button>}</td>

    </tr>
    )
}
