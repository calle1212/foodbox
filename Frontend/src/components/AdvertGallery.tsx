import {
    useQuery,
} from '@tanstack/react-query'
import { Post } from '../types';
import AdvertCard from './AdvertCard';
import { useUser } from '@clerk/clerk-react';
import { useEffect } from 'react';



export default function AdvertGallery() {

    const { user } = useUser();

    useEffect(() => {
        if (user) {
            const postUserToBackend = async () => {
                const userData = {
                    clerkId: user.id,
                    name: user.username
                };

                const response = await fetch('http://localhost:5063/api/users', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(userData),
                });

                if (!response.ok) {
                    console.error('Failed to send user data to backend:', response.statusText);
                }
            };

            postUserToBackend();
            console.log("ran PostUserToBackend");
        }
    }, [user]);



    //const sectionProps: sectionProps = { salties: data.salties }
    const { isPending, error, data, isFetching } = useQuery<Post[]>({
        queryKey: ["repoData"],
        queryFn: async () => {
            const response = await fetch(
                'http://localhost:5063/api/Posts',
            )
            return await response.json()
        },
    })

    if (isPending) return 'Loading...';
    if (error) return 'An error has occurred: ' + error.message
    if (isFetching) return "is fetching...";
    return (
        <div className='flex gap-4'>
            {data.map(post => <AdvertCard {...post} key={post.id}/>)}
        </div>
    )
}