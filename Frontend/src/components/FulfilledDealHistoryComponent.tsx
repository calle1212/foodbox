import { Post } from "../types";
import { Link } from '@tanstack/react-router';


export default function FulfilledDealHistoryComponent(post : Post){
    if(post.isFulfilled){
        return (
        <tr>
            <td>{post.title}</td>
            <td>{post.description}</td>
            <td>{post.date}</td>
            <td> <Link to="/profile" search={{id: post.creatorClerkId}} className="btn"> Fulfiller profile</Link>{post.fulfillerClerkId}</td>
            <td>{post.reviewOnCreator && post.reviewOnCreator.rating}</td>
        </tr>
        )
    }
}