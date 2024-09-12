import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query';
import { Post } from '../types';
import { useMatch , Link} from '@tanstack/react-router';
import { useUser } from '@clerk/clerk-react';

export default function AdvertPage(){
    const { search } = useMatch("/deal");
    const qid= search.id;
  
    const { isPending, error, data, isFetching } = useQuery<Post>({
        queryKey: ["UserPost"],
        queryFn: async () => {
            const response = await fetch(
                `http://localhost:5063/api/Users/ActivePost?ClerkId=${qid}`,
            )
            return await response.json()
        },
    })
    const user= useUser();

    const queryClient = useQueryClient();

    const acceptJobQuery  = useMutation({
        mutationFn: () => {
            return fetch(`http://localhost:5063/api/Posts/AcceptJob?fulfillerClerkId=${user.user?.id}&postId=${data?.id}`, {
                method: "PATCH",
            })
        },
        onSuccess: () => queryClient.invalidateQueries({ queryKey: ["UserPost"] }) 
    });

    
    if (isPending) return 'Loading...';
    if (error) return 'An error has occurred: ' + error.message
    if (isFetching) return "is fetching...";
    
    function acceptJob(){
        console.log("hello from accept job")
        acceptJobQuery.mutate();
    }
    
    const Post = data;
    console.log(user.user?.id)
    console.log(Post.fulfillerClerkId)
    return (
        <div className='flex flex-col items-center'>
            <h1 className='text-3xl'>{Post?.title}</h1>
            <figure className='max-w-96'>
                    <img
                        src={Post?.imageUrl || "https://images.pexels.com/photos/1860208/pexels-photo-1860208.jpeg?cs=srgb&dl=cooked-food-1860208.jpg&fm=jpg"}
                        alt="Food image" />
                </figure>
                <ul>
                    <li></li>
            <li>Creator: {Post.creatorName}</li>
            <li>Description: {Post?.description}</li>
            <li>Come over at: {Post?.date}</li>
            <li>Address: {Post?.location}</li>
            <li>Payment: {Post?.payment} kr</li>
            </ul>
            <div className='p-4'>

            { Post.fulfillerClerkId != "" && <button className='btn btn-disabled' >This has job already been accepted</button>}
            { Post.fulfillerClerkId == "" && <button className='btn btn-primary' onClick={acceptJob}>Take Job</button>}
            </div>
            <div className='p-10'>
            <Link to="/profile" search={{id: Post?.creatorClerkId}} className='btn'>Check out {Post.creatorName}'s profile</Link>
            </div>
        </div>
    )
}